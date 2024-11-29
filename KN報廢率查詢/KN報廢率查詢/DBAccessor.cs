using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using DataBase;
using System.Data;
using MySql.Data.MySqlClient;
using KN報廢率查詢.Properties;

namespace KN報廢率查詢
{
    class DBAccessor : MysqlDB
    {
        public DBAccessor(string connString) : base(connString)
        {

        }
        
        public DBAccessor() : base(Settings.Default.mysqlConnString) { }
        
        DataTable Dt = new DataTable();
        
        public DataTable GetValBy_eng_num(string eng_num, string start, string end, int pcs)
        {            
            string queryString = string.Format(@"select distinct vm.partNo, SUBSTR(vm.wo_num, 1, 6) 批號, vm.pnl_id SpnlID, d.VI_Xout VI_Xout數, concat(truncate(d.VI_Xout/{3}*100, 2), '%') 報廢率
                                   from gmsys.gm_vi_xout_main vm 
                                   left join gmsys.acm_detial d
                                   on vm.pnl_id = d.spnlID
                                   where vm.partNo like '{0}%' and d.CreateDate between '{1}' and '{2}' and truncate(d.VI_Xout/{3}*100, 2) > 7.5", eng_num, start, end, pcs);

            Dt = ConnMySqlReturnDataTable(queryString);            
            return Dt;            
        }

        public DataTable GetValBy_wo_num(int wo_num, int pcs)
        {
            string queryString = string.Format(@"select distinct SUBSTR(vm.wo_num, 1, 6) 批號, vm.pnl_id SpnlID, d.VI_Xout VI_Xout數, concat(truncate(d.VI_Xout/{1}*100, 2), '%') 報廢率
                                                 from gm_vi_xout_main vm 
                                                 left join acm_detial d on vm.pnl_id = d.spnlID
                                                 where vm.wo_num like '{0}%' and truncate(d.VI_Xout/{1}*100, 2) > 7.5", wo_num, pcs);

            Dt = ConnMySqlReturnDataTable(queryString);
            return Dt;
        }

        public DataTable GetDefectRateByLot(int lot, int flag)
        {
            string condiction = "";
            if (flag == 0)
                condiction = " and ( acm.flag=0 or acm.flag is null)";
            else
                condiction = " and acm.flag=1 ";

            string queryString = string.Format(@"select  '目檢' type,aa.lot,bb.countSpnlByLot,cc.pcsOfSpnl,defect_code,wastecoderemark,sum(quantity) xoutCount
		                                                    ,format(sum(quantity) /(pcsOfSpnl*bb.countSpnlByLot)*100,5) 'defectRate'
                                                    from (
	                                                    SELECT spnls.*,d.*,c.wastecoderemark 
	                                                    FROM  (SELECT substring( trim(gvi.wo_num),1,6)  lot,gvi.pnl_id spnlid,gvi.gvistarttime
					                                                    FROM gmsys.gm_vi_xout_main gvi
					                                                    left join acm_detial acm on gvi.pnl_id =acm.spnlid
					                                                    where
					                                                    wo_num like '{0}%'
					                                                  "+condiction+ @"
					                                                    ) spnls			
				                                                    inner join  gmsys.gm_vi_double_check_detail d on spnls.spnlid=d.spnl_id 
				                                                    inner join gm_vi_waste_code c on d.defect_code=c.wasteCode
	                                                    ) aa
                                                        inner join 
                                                        (/*select substring( trim(gvi.wo_num),1,6)  lot,count(1) countSpnlByLot FROM gmsys.gm_vi_xout_main gvi
					                                                    left join acm_detial acm on gvi.pnl_id =acm.spnlid
					                                                    where
					                                                    wo_num like '{0}%'
					                                                    " + condiction + @" */

                                                         SELECT substring(trim(am.RunCard),1,6) lot, count(acm.spnlID) countSpnlByLot
																		FROM gmsys.acm_main am
																		inner join gmsys.acm_detial acm on am.RKey = acm.ACM_Main_ptr
																		where am.RunCard like '{0}%' 
                                                                        " + condiction + @" 
                                                                            ) bb on aa.lot=bb.lot
	                                                    inner join 
                                                        (SELECT substring( trim(base_no),1,6)  lot,pcsx*pcsy pcsOfSpnl FROM gmsys.gm_os2_main ) cc on 	aa.lot=cc.lot
                                                    group by lot,defect_code    
                                                    union
                                                    -- 查指定批號GVI缺陷數量比例
                                                    select  'GVI' type,aa.lot,bb.countSpnlByLot,dd.pcsOfSpnl,defect_code,cc.wastecoderemark ,count(1) xoutCount ,format( count(1)/(bb.countSpnlByLot*dd.pcsOfSpnl)*100,5) 'defectRate'
                                                    from 
	                                                    (select  *,substring( trim(wo_num),1,6) lot
	                                                    from gm_vi_xout_main m left join gm_vi_xout_data d on m.rkey=d.gm_vi_xout_main_ptr 
	                                                     where   wo_num like '{0}%'	and defect_code is not null        
	                                                     group by substring( trim(wo_num),1,6),m.pnl_id,d.pcs_index      
	                                                     ) aa
                                                         inner join   (SELECT substring(trim(am.RunCard),1,6) lot, count(acm.spnlID) countSpnlByLot
																		FROM gmsys.acm_main am
																		inner join gmsys.acm_detial acm on am.RKey = acm.ACM_Main_ptr
																		where am.RunCard like '{0}%' 
                                                                        " + condiction + @" 
                                                                              ) bb
	                                                     on aa.lot=bb.lot  
                                                        inner join gm_vi_waste_code cc on aa.defect_code=cc.wasteCode
                                                        inner join  (SELECT substring( trim(gvi.wo_num),1,6)  lot,gvi.pnl_id spnlid,gvi.gvistarttime
					                                                    FROM gmsys.gm_vi_xout_main gvi
					                                                    left join acm_detial acm on gvi.pnl_id =acm.spnlid
					                                                    where
					                                                    wo_num like '{0}%'
					                                                     " + condiction + @"
					                                                    ) spnls			
	                                                    on  spnls.spnlid=aa.pnl_id 
                                                        inner join     (SELECT substring( trim(base_no),1,6)  lot,pcsx*pcsy pcsOfSpnl FROM gmsys.gm_os2_main ) dd
                                                        on 	aa.lot=dd.lot
                                                     group by defect_code", lot);

            Dt = ConnMySqlReturnDataTable(queryString);
            return Dt;
        }        
    }

    public class DBAccessor_SFC : MysqlDB
    {
        public DBAccessor_SFC(string connString) : base(connString)
        {

        }

        public DBAccessor_SFC() : base(Settings.Default.sfcMysqlConnString) { }

        DataTable Dt = new DataTable();

        public DataTable GetValBy_part_number(string part_number)
        {
            string queryString = string.Format(@"SELECT distinct customer_part_number 板號, eng_num 工號, pcs_spnl Spnl_Pcs數
                                                FROM sfc3.sfc_wo_information
                                                where customer_part_number like '{0}%'", part_number);

            Dt = ConnMySqlReturnDataTable(queryString);
            return Dt;
        }

        public DataTable GetValBy_wo_num(int wo_num)
        {
            string queryString = string.Format(@"SELECT distinct wo_num, customer_part_number 板號, eng_num 工號, pcs_spnl Spnl_Pcs數
                                                 FROM sfc3.sfc_wo_information
                                                 where wo_num = '{0}'", wo_num);
            
            Dt = ConnMySqlReturnDataTable(queryString);            
            return Dt;
        }
    }
}
