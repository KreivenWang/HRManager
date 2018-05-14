//using System;
//using System.Collections.Generic;
//using System.Linq;
//using System.Text;
//using System.IO;
//using System.Collections;
//using HRManagerDataAccess;
//using HRModel;
//using System.Runtime.Serialization;
//using System.Runtime.Serialization.Formatters.Binary;

//namespace HrControl
//{

//    public class AttendanceWrapper
//    {
//        public void Analyse()
//        {
//            var employees = HrManagerContext.GetInstance().Employees.ToList();
//            int month = 5;
//            foreach (Employee employee in employees)
//            {
//                CalculateTime(employee, month);
//            }
//        }
//        private VacationPlan GetVactionPlans(Employee employee)
//        {
//            var vactionPlans = HrManagerContext.GetInstance().VacationPlans;
//            if (vactionPlans.Any(v => v.EmployeeId == employee.Id))
//                return vactionPlans.Where(v => v.EmployeeId == employee.Id).ToList()[0];
//            if (vactionPlans.Any(v => v.OperatingPostId == employee.OperatingPostId))
//                return vactionPlans.Where(v => v.DepartmentId == employee.DepartmentId).ToList()[0];
//            if (vactionPlans.Any(v => v.DepartmentId == employee.DepartmentId))
//                return vactionPlans.Where(v => v.DepartmentId == employee.DepartmentId).ToList()[0];
//            return vactionPlans.ToList().Where(a => a.IsCommonDefine).ToList()[0];
//        }
//        private List<ArrangeWork> GetArrangeWorks(Employee employee)
//        {
//            var arrangeWorks = HrManagerContext.GetInstance().ArrangeWorks.ToList();
//            var emparrangeWorks = arrangeWorks.Where(a => a.Employee == employee).ToList();
//            if (emparrangeWorks.Count != 0) return emparrangeWorks;
//            var operatarrangeWorks = arrangeWorks.Where(a => a.OperatingPost == employee.OperatingPost).ToList();
//            if (operatarrangeWorks.Count != 0) return operatarrangeWorks;
//            var departarrangeWorks = arrangeWorks.Where(a => a.Department == employee.Department).ToList();
//            if (departarrangeWorks.Count != 0) return departarrangeWorks;
//            return arrangeWorks.Where(a => a.IsCommonDefine).ToList();
//        }
//        private List<ArrangeWork> GetArrangeWorkByNo(List<ArrangeWork> arrangeWorks, String num)
//        {
//            return arrangeWorks.Where(a => a.ArrangeWorkNo == num).ToList();
//        }
//        //字典排序
//        private Dictionary<string, DateTime> DictonarySort(Dictionary<string, DateTime> dic)
//        {
//            //var dicSort = from objDic in dic orderby objDic.Value select objDic;
//            return dic.OrderBy(s => s.Value).ToDictionary(k => k.Key, v => v.Value);
//            //foreach (KeyValuePair<string, DateTime> kvp in dicSort)
//            //    Response.Write(kvp.Key + "：" + kvp.Value + "<br />");
//        }

//        /// 得到一个对象的克隆
//        public static object Clone(object obj)
//        {
//            MemoryStream memoryStream = new MemoryStream();
//            BinaryFormatter formatter = new BinaryFormatter();
//            formatter.Serialize(memoryStream, obj);
//            memoryStream.Position = 0;
//            return formatter.Deserialize(memoryStream);
//        }

//        public DateTime delYearMonthDay(DateTime dt)
//        {
//            String str = dt.ToString("hh:mm:ss");
//            return DateTime.Parse(str);
//        }


//        //// 获取今天第一张请假单的数据并计算每张请假单的差值存于list中
//        //public void GetTodayAskTimeDiffValue(List<AskLeave> today_askleave, List<int> tmp)
//        //{
//        //    // 遍历今天所有的请假单并计算请假时长
//        //    foreach (AskLeave tmp_ask in today_askleave)
//        //    {
//        //        tmp.Add((int)((TimeSpan)DateTime.Parse(tmp_ask.EndDate).Subtract(DateTime.Parse(tmp_ask.BeginDate))).TotalHours +
//        //            ((int)((TimeSpan)DateTime.Parse(tmp_ask.EndDate).Subtract(DateTime.Parse(tmp_ask.BeginDate))).TotalMinutes/60));
//        //    }
//        //}

//        //public void GetTodayBustTimeDiffValue(List<BusinessTrip> today_bust, List<int> tmp)
//        //{
//        //    // 遍历今天所有的出差单 并计算出差时长
//        //    foreach (BusinessTrip tmp_bust in today_bust)
//        //    {
//        //        tmp.Add((int)((TimeSpan)DateTime.Parse(tmp_bust.EndDate).Subtract(DateTime.Parse(tmp_bust.BeginDate))).TotalHours + 
//        //            ((int)((TimeSpan)DateTime.Parse(tmp_bust.EndDate).Subtract(DateTime.Parse(tmp_bust.BeginDate))).TotalMinutes)/60);
//        //    }
//        //}

//        //public void GetTodayOverWorkTimeDiffValue( List<OverWork> list_over, List<int> tmp )
//        //{
//        //    // 遍历今天所有的加班单 并计算加班时长

//        //    foreach (OverWork tmp_ovwork in list_over)
//        //    {
//        //        tmp.Add((int)((TimeSpan)DateTime.Parse(tmp_ovwork.EndDateTime).Subtract(DateTime.Parse(tmp_ovwork.BeginDateTime))).TotalHours +
//        //            ((int)((TimeSpan)DateTime.Parse(tmp_ovwork.EndDateTime).Subtract(DateTime.Parse(tmp_ovwork.BeginDateTime))).TotalMinutes/60));
//        //    }
//        //}

//        // 除了Employee和ArrangeWork外，其他参数均对应只某个员工上个月的信息
//        // 返回的字典有五组元素<int,List<int>>，通过key值获取value，0为本月的工作时间，1为本月的缺勤时间，2为本月的请假时间
//        // 3为本月的出差时间，4为本月的加班时间
//        // List<int>包含本月每个工作日的各种时间
//        public List<AttendanceResult> CalculateTime(Employee employee, int month)
//        {
//            int daycount; // 日期计数
//            VacationPlan vactionPlan = GetVactionPlans(employee);
//            List<AttendanceResult> list_attResult = new List<AttendanceResult>();
            //List<int> workTime = new List<int>(); // 工作时间
            //List<int> absenteeismTime = new List<int>(); // 旷工时间
//            List<int> askLeTime = new List<int>(); // 请假时间
//            List<int> bussTrTime = new List<int>(); // 出差时间
//            List<int> ovWorkTime = new List<int>(); // 加班时间
//            AttendanceAnalysis attAna = new AttendanceAnalysis();

//            var attendanceForMonth =
//                HrManagerContext.GetInstance()
//                    .Attendances.Where(a => a.EmployeeNo == employee.EmployeeNO).ToList().FindAll(a => a.RecordTimeToDateTime.Month == month).ToList();

//            var arrageworks = GetArrangeWorks(employee);

//            var overWorkForMonth =
//                HrManagerContext.GetInstance()
//                    .OverWorks.Where(o => o.EmployeeId == employee.EmployeeId)
//                    .ToList().FindAll(a => a.BeginDateTimeToDateTime.Month == month).ToList();

//            var businessTripsForMonth =
//                HrManagerContext.GetInstance()
//                    .BusinessTrips.Where(b => b.EmployeeId == employee.EmployeeId).ToList()
//                    .FindAll(a => a.BeginDateToDateTime.Month == month).ToList();

//            var reSignInForMonth =
//                HrManagerContext.GetInstance()
//                    .ReSignIns.Where(r => r.EmployeeId == employee.EmployeeId).ToList().FindAll(a => a.ReSignInDateToDateTime.Month == month).ToList();

//            var askLeaveForMonth =
//                HrManagerContext.GetInstance()
//                    .AskLeaves.Where(a => a.EmployeeId == employee.EmployeeId).ToList().FindAll(a => a.BeginDateToDateTime.Month == month).ToList(); 
            
//            daycount = DateTime.DaysInMonth(DateTime.Parse(attendanceForMonth[0].RecordTime).Year, month);
//            int year = DateTime.Parse(attendanceForMonth[0].RecordTime).Year;

//            for (int i = 1; i < daycount; i++)
//            {
//                AttendanceResult att_result = new AttendanceResult();
//                AttendanceToday att_today = attAna.AnalysisForPresonByDay(arrageworks, attendanceForMonth, overWorkForMonth, businessTripsForMonth,
//                    reSignInForMonth, askLeaveForMonth, i);
                //List<float> askLeaveTime = new List<float>(); // 请假时间差值
                //List<String> reSignTime = new List<string>(); // 补签的时间点
                //float bustTime; // 出差时间差值
                //float overWorkTime_normal; //周末加班时间
//                float overWorkTime_vocation; //法定假日加班时间
//                int j = 0;
//                att_result.EmployeeNo = employee.EmployeeNO;
//                att_result.EmployeeName = employee.EmployeeBaseInfo.EmployName;
//                List<int> index = new List<int>();
//                //// 找出今天所有的请假单并计算请假时长
//                //GetTodayAskTimeDiffValue(att_today.today_askleave, askLeaveTime);

//                //// 找出今天所有的出差单 并计算出差时长
//                //GetTodayBustTimeDiffValue(att_today.today_bust, bustTime);

//                //// 找出今天所有的加班单 并计算出加班时间
//                //GetTodayOverWorkTimeDiffValue(att_today.today_overwork, overWorkTime_normal);

//                // 找出今天所有的补签单
//                foreach (DateTime tmp_resign in att_today.ReSiginToday)
//                {
//                    reSignTime.Add(tmp_resign.TimeOfDay.ToString());
//                }

//                // 这一天没有考勤记录
//                if (att_today.VirAttendanceDateTimes.Count == 0)
//                {
//                    String str = "";
//                    if (month < 10 && daycount < 10)
//                    {
//                        str = year.ToString() + "0" + month.ToString() + "0" + daycount.ToString();
//                    }
//                    else if (month > 10 && daycount < 10)
//                    {
//                        str = year.ToString() + month.ToString() + "0" + daycount.ToString();
//                    }
//                    else if (month < 10 && daycount > 10)
//                    {
//                        str = year.ToString() + "0" + month.ToString() + daycount.ToString();
//                    }
//                    else if (month > 10 && daycount > 10)
//                    {
//                        str = year.ToString() + month.ToString() + daycount.ToString();
//                    }
                    
//                    DateTime dt = DateTime.ParseExact(str, "yyyyMMdd", System.Globalization.CultureInfo.CurrentCulture);
//                    // 判断是否为假期
//                    if (vactionPlan.Saturdays.Contains(dt))
//                    {
//                        i++;
//                        continue;
//                    }
//                    else if (vactionPlan.Sundays.Contains(dt))
//                    {
//                        i++;
//                        continue;
//                    }
//                    else if (vactionPlan.VacationDays.Contains(dt))
//                    {
//                        i++;
//                        continue;
//                    }
//                    else
//                    {
//                        absenteeismTime.Add(8);
//                        i++;
//                        continue;
//                    }
//                }
//                else
//                {
//                    // 匹配班次
//                    String correct_arrwork = att_today.ArrangeWorkNo;
//                    if (correct_arrwork != String.Empty)
//                    {
//                        var correct_arrworks = GetArrangeWorkByNo(arrageworks, correct_arrwork);

//                        int correct_worktime = 0;

//                        if (correct_arrworks.Count == 2)
//                        {
//                            att_result.BanCi = correct_arrworks[0].WorkName;

//                            // 获取该班次正常工作的工作时长
//                             correct_worktime = Math.Abs((int)((TimeSpan)DateTime.Parse(correct_arrworks[0].OffDutyTime).Subtract(DateTime.Parse(correct_arrworks[1].OnDutyTime))).TotalHours +
//                                ((int)((TimeSpan)DateTime.Parse(correct_arrworks[0].OffDutyTime).Subtract(DateTime.Parse(correct_arrworks[1].OnDutyTime))).TotalMinutes / 60));
//                            att_result.AttendanceDate = att_today.VirAttendanceDateTimes[0].ToString("yyyy/MM/dd");
//                        }
//                        else
//                        {
//                            att_result.BanCi = correct_arrworks[0].WorkName;

//                            // 获取该班次正常工作的工作时长
//                             correct_worktime = Math.Abs((int)((TimeSpan)DateTime.Parse(correct_arrworks[0].OffDutyTime).Subtract(DateTime.Parse(correct_arrworks[0].OnDutyTime))).TotalHours +
//                                ((int)((TimeSpan)DateTime.Parse(correct_arrworks[0].OffDutyTime).Subtract(DateTime.Parse(correct_arrworks[0].OnDutyTime))).TotalMinutes / 60));
//                            att_result.AttendanceDate = att_today.VirAttendanceDateTimes[0].ToString("yyyy/MM/dd");
//                        }
//                        List<String> tmp_date = new List<String>();
//                        for (int att = 0; att < att_today.VirAttendanceDateTimes.Count(); att++)
//                        {
//                            foreach (Attendance tmp_att in att_today.AttendancesForDay)
//                            {
//                                if (att_today.VirAttendanceDateTimes[att] == tmp_att.RecordTimeToDateTime)
//                                    tmp_date.Add(att_today.VirAttendanceDateTimes[att].ToString("hh:mm:ss"));
//                            }

//                        }
//                        var tmp_datacount = tmp_date.Count;
//                        if (tmp_date.Count < 6)
//                        {
//                            for (int d = 5; d >= tmp_datacount; d--)
//                            {
//                                tmp_date.Add("");
//                            }
//                        }
//                        att_result.OnDutyMorning = tmp_date[0];
//                        att_result.OffDutyMorning = tmp_date[1];
//                        att_result.OnDutyNoon = tmp_date[2];
//                        att_result.OffDutyNoon = tmp_date[3];
//                        att_result.OnDutyNight = tmp_date[4];
//                        att_result.OffDutyNight = tmp_date[5];

                        //foreach (AskLeave tmp_ask in att_today.AskleavesToDay)
                        //{
                        //    if (tmp_ask.LeaveType == "病假")
                        //    {
                        //        att_result.AskBingJia += ((float)((TimeSpan)tmp_ask.EndDateToDateTime.Subtract(tmp_ask.BeginDateToDateTime)).TotalHours +
                        //                ((float)((TimeSpan)tmp_ask.EndDateToDateTime.Subtract(tmp_ask.BeginDateToDateTime)).TotalMinutes / 60));
                        //    }
                        //    else if (tmp_ask.LeaveType == "事假")
                        //    {
                        //        att_result.AskShiJia += ((float)((TimeSpan)tmp_ask.EndDateToDateTime.Subtract(tmp_ask.BeginDateToDateTime)).TotalHours +
                        //                ((float)((TimeSpan)tmp_ask.EndDateToDateTime.Subtract(tmp_ask.BeginDateToDateTime)).TotalMinutes / 60));
                        //    }
                        //    else if (tmp_ask.LeaveType == "工伤假")
                        //    {
                        //        att_result.AskGongShangJia += ((float)((TimeSpan)tmp_ask.EndDateToDateTime.Subtract(tmp_ask.BeginDateToDateTime)).TotalHours +
                        //                ((float)((TimeSpan)tmp_ask.EndDateToDateTime.Subtract(tmp_ask.BeginDateToDateTime)).TotalMinutes / 60));
                        //    }
                        //    else if (tmp_ask.LeaveType == "年假")
                        //    {
                        //        att_result.AskNianJia += ((float)((TimeSpan)tmp_ask.EndDateToDateTime.Subtract(tmp_ask.BeginDateToDateTime)).TotalHours +
                        //                ((float)((TimeSpan)tmp_ask.EndDateToDateTime.Subtract(tmp_ask.BeginDateToDateTime)).TotalMinutes / 60));
                        //    }
                        //    else if (tmp_ask.LeaveType == "婚假")
                        //    {
                        //        att_result.AskHunJia += ((float)((TimeSpan)tmp_ask.EndDateToDateTime.Subtract(tmp_ask.BeginDateToDateTime)).TotalHours +
                        //                ((float)((TimeSpan)tmp_ask.EndDateToDateTime.Subtract(tmp_ask.BeginDateToDateTime)).TotalMinutes / 60));
                        //    }
                        //    else if (tmp_ask.LeaveType == "产假")
                        //    {
                        //        att_result.AskChanJia += ((float)((TimeSpan)tmp_ask.EndDateToDateTime.Subtract(tmp_ask.BeginDateToDateTime)).TotalHours +
                        //                ((float)((TimeSpan)tmp_ask.EndDateToDateTime.Subtract(tmp_ask.BeginDateToDateTime)).TotalMinutes / 60));
                        //    }
                        //    else
                        //    { }
                        //}

                        //att_result.TiaoXiu = "";
                        //foreach (DateTime tmp_resignIn in att_today.ReSiginToday)
                        //{
                        //    att_result.ReSignIn = tmp_resignIn.ToString("hh:mm:ss");
                        //}

                        //foreach (OverWork tmp_over in att_today.OverWorksToday)
                        //{
                        //    att_result.OverWork += ((float)((TimeSpan)tmp_over.EndDateTimeToDateTime.Subtract(tmp_over.BeginDateTimeToDateTime)).TotalHours +
                        //                ((float)((TimeSpan)tmp_over.EndDateTimeToDateTime.Subtract(tmp_over.BeginDateTimeToDateTime)).TotalMinutes / 60));
                        //}

                        //foreach (BusinessTrip tmp_bust in att_today.BusinessTripsToDay)
                        //{
                        //    att_result.BusTrip += ((float)((TimeSpan)tmp_bust.EndDateToDateTime.Subtract(tmp_bust.BeginDateToDateTime)).TotalHours +
                        //                ((float)((TimeSpan)tmp_bust.EndDateToDateTime.Subtract(tmp_bust.BeginDateToDateTime)).TotalMinutes / 60));
                        //}
                        //list_attResult.Add(att_result);


//                        // 打卡1次以上
//                        if (att_today.VirAttendanceDateTimes.Count >= 1 && att_today.VirAttendanceDateTimes.Count < 6)
//                        {
                            //if (att_today.AskleavesToDay.Count > 0)
                            //{
                            //    // 有请假单
                            //    if (att_result.AskBingJia != 0)
                            //    {
                            //        askLeaveTime.Add(att_result.AskBingJia);
                            //    }
                            //    else if (att_result.AskShiJia != 0)
                            //    {
                            //        askLeaveTime.Add(att_result.AskShiJia);
                            //    }
                            //}
                            //else if (att_today.BusinessTripsToDay.Count > 0)
                            //{
                            //    // 有出差单
                            //    bustTime = att_result.BusTrip;
                            //}
                            //else if (att_today.OverWorksToday.Count > 0)
                            //{
                            //    // 有加班单
                            //    if (vactionPlan.VacationDays.Contains(att_today.OverWorksToday[0].BeginDateTimeToDateTime))
                            //    {
                            //        overWorkTime_vocation = att_result.OverWork;
                            //    }
                            //    else
                            //    {
                            //        overWorkTime_normal = att_result.OverWork;
                            //    }
                            //}
                            //else
                            //{
                            //    if (reSignTime.Count == 0)
                            //    {
                            //        //旷工
                            //    }
                            //}
//                        }
//                        else
//                        {
//                            // 正常打卡
//                            workTime.Add(correct_worktime);
//                        }

//                    }
//                }
                    
//            }
//            //统计出此人该月的出勤情况
//            return list_attResult;
//        }
//    }
//}
