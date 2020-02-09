using CloudbassCRUDII.Models;
using CloudbassCRUDII.Models.DTO;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace CloudbassCRUDII.Repository
{
    public class JobRepository
    {

        public List<Models.DTO.Job> GetJobs()
        {
            using (var context = new cloudbassDBMSEntities())
            {
                List<Models.Job> jobs = new List<Models.Job>();
                jobs = context.Jobs.AsNoTracking()
                    //.Include(j => j.)
                    .ToList();

                if (jobs != null)
                {
                    List<Models.DTO.Job> jobsDisplay = new List<Models.DTO.Job>();

                    foreach (var j in jobs)
                    {
                        var jobDisplay = new Models.DTO.Job()
                        {
                            Id = j.Id,
                            text = j.text,
                            //NameConcatenateLocation = j.
                            DateCreated = j.DateCreated,
                            Location = j.Location,
                            Coordinator = j.Coordinator,
                            ClientId = j.ClientId,

                            start_date = j.start_date,
                            TXDate = j.TXDate,
                            end_date = j.end_date,
                            CommercialLead = j.CommercialLead
                            // Status = j.Status
                        };

                        jobsDisplay.Add(jobDisplay);
                    }

                    return jobsDisplay;
                }

                return null;
            }


        }


        public JobEdit GetJob(string id)
        {
            if (id != string.Empty)
            {
                using (var context = new cloudbassDBMSEntities())
                {
                    var job = context.Jobs.AsNoTracking()
                                            .Where(j => j.Id == id)
                                            .Single();

                    if (job != null)
                    {
                        var jobEditVm = new JobEdit()
                        {
                            Id = job.Id/*.ToString("")*/,
                            text = job.text.Trim(),
                            Description = job.Description,
                            //NameConcatenateLocation = j.
                            DateCreated = job.DateCreated,
                            Location = job.Location,
                            Coordinator = job.Coordinator,
                            // ClientName = j.Client.Name,

                            start_date = job.start_date,
                            TXDate = job.TXDate,
                            end_date = job.end_date,
                            CommercialLead = job.CommercialLead,
                            SelectedClient = job.ClientId,
                            SelectedStatus = job.JobStatu.Id

                        };
                        var clientsRepo = new ClientRepository();
                        jobEditVm.Client = clientsRepo.GetClients();
                        var jobStatuRepo = new JobStatuRepository();
                        jobEditVm.JobStatu = jobStatuRepo.GetJobStatus(/*job.statusId*/);

                        return jobEditVm;
                    }
                    // return job;
                }
            }
            return null;
        }

            public JobEdit CreateJob()
            {

                var cRepo = new ClientRepository();

                var sRepo = new JobStatuRepository();

                var job = new JobEdit()
                {
                    Id = ToString(),
                    //Id = Guid.NewGuid().ToString(),
                    // Id = string.IsNullOrEmpty(string).ToString(),
                    Client = cRepo.GetClients(),
                    JobStatu = sRepo.GetJobStatus()

                };

                return job;
            }

            public bool SaveJob(JobEdit jobedit)
            {
                if (jobedit != null)
                {
                    using (var context = new cloudbassDBMSEntities())
                    {

                        if (string.IsNullOrEmpty(jobedit.Id))
                        {

                            var job = new Models.Job()
                            {
                                //Id = newGuid.ToString(),
                                Id = ToString(),
                                text = jobedit.text,
                                ClientId = jobedit.SelectedClient,
                                Location = jobedit.Location,
                                Coordinator = jobedit.Coordinator,
                                //NameConcatenateLocation = jobEdit.Name,
                                start_date = jobedit.start_date,
                                TXDate = jobedit.TXDate,
                                end_date = jobedit.end_date,
                                statusId = jobedit.SelectedStatus,
                                CommercialLead = jobedit.CommercialLead,


                            };

                            job.Client = context.Clients.Find(jobedit.SelectedClient);
                            job.JobStatu = context.JobStatus.Find(jobedit.SelectedStatus);
                            context.Jobs.Add(job);
                            context.SaveChanges();
                            return true;
                        }
                    }
                }

                // Return false if customeredit == null or CustomerID is not a guid
                return false;
            }

        // START SCHEDULE LIST

        // public List<Models.DTO.ScheduleListView> GetScheduleList(string jobid)
        public Models.DTO.ScheduleListView GetScheduleList(string jobid)
        {
            if (jobid != string.Empty)
            {
                using (var context = new cloudbassDBMSEntities())
                {
                    var schedules = context.Schedules.AsNoTracking()
                        .Where(x => x.JobId == jobid)
                        .OrderBy(x => x.Id);

                    if (schedules != null)
                    {
                        var scheduleListView = new ScheduleListView();
                        foreach (var schedule in schedules)
                        {
                            var scheduleVm = new Models.DTO.Schedule()
                            {
                                JobId = schedule.JobId,
                                Id = schedule.Id,
                                text = schedule.text,
                                //SchTypeId = schedule.SchTypeId,
                                //SchTypName = schedule.SchType.name,
                                start_date = schedule.start_date,
                                end_date = schedule.end_date,
                                //StatusName = schedule.ScheduleStatu.title

                            };

                            var schTypesRepo = new SchTypeRepository();
                            scheduleVm.SchTypName = schTypesRepo.GetSchTypes().ToString();
                            var scheduleStatuRepo = new ScheduleStatuRepository();
                            scheduleVm.StatusName = scheduleStatuRepo.GetScheduleStatus().ToString();
                            scheduleListView.Schedules.Add(scheduleVm);
                        }
                        return scheduleListView;
                    }
                }
            }
            return null;
        }


        //START SECOND

        //public List<Models.DTO.Schedule> GetSchedule(string jobid, int scheduleid)
        public Models.DTO.Schedule GetSchedule(string jobid, int scheduleid)
        {
            if (jobid != string.Empty)
            {
                using (var context = new cloudbassDBMSEntities())
                {
                    var schedule = context.Schedules.AsNoTracking()
                        .Where(x => x.JobId == jobid && x.Id == scheduleid)
                        .Single();


                    if (schedule != null)
                    {
                        var scheduleVm = new Models.DTO.Schedule()
                        {
                            JobId = schedule.JobId,
                            
                            text = schedule.text?.Trim(),
                            
                            start_date = schedule.start_date,
                            end_date = schedule.end_date,
                           

                        };

                        var schTypesRepo = new SchTypeRepository();
                        scheduleVm.SchTypName = schTypesRepo.GetSchTypes().ToString();
                        var scheduleStatuRepo = new ScheduleStatuRepository();
                        scheduleVm.StatusName = scheduleStatuRepo.GetScheduleStatus().ToString();
                        return scheduleVm;
                    }

                }
            }
            return null;

        }


            //END SECOND







        //public JobEdit GetSchedule(string id)
        //{
        //    if (id != string.Empty)
        //    {
        //        using (var context = new cloudbassDBMSEntities())
        //        {
        //            var job = context.Jobs.AsNoTracking()
        //                                    .Where(j => j.Id == id)
        //                                    .Single();

        //            if (job != null)
        //            {
        //                var jobEditVm = new JobEdit()
        //                {
        //                    Id = job.Id/*.ToString("")*/,
        //                    text = job.text.Trim(),
        //                    Description = job.Description,
        //                    //NameConcatenateLocation = j.
        //                    DateCreated = job.DateCreated,
        //                    Location = job.Location,
        //                    Coordinator = job.Coordinator,
        //                    // ClientName = j.Client.Name,

        //                    start_date = job.start_date,
        //                    TXDate = job.TXDate,
        //                    end_date = job.end_date,
        //                    CommercialLead = job.CommercialLead,
        //                    SelectedClient = job.ClientId,
        //                    SelectedStatus = job.JobStatu.Id

        //                };
        //                var clientsRepo = new ClientRepository();
        //                jobEditVm.Client = clientsRepo.GetClients();
        //                var jobStatuRepo = new JobStatuRepository();
        //                jobEditVm.JobStatu = jobStatuRepo.GetJobStatus(/*job.statusId*/);

        //                return jobEditVm;
        //            }
        //            // return job;
        //        }
        //    }
        //    return null;
        //}

       

        public ScheduleEdit SaveSchedule(ScheduleEdit model)
        {
            if (model != null && string.IsNullOrEmpty(model.JobId) )
            {
                using (var context = new cloudbassDBMSEntities())
                {

                    //if (string.IsNullOrEmpty(jobedit.Id))
                    //{

                        var schedule = new Models.Schedule()
                        {
                            //Id = newGuid.ToString(),
                            JobId = model.JobId,
                            text = model.text,
                           
                            start_date = model.start_date,
                            
                            end_date = model.end_date,
                            statusId = model.statusId,
                            SchTypeId = model.SchTypeId


                        };

                        schedule.SchType = context.SchTypes.Find(schedule.SchTypeId);
                        schedule.ScheduleStatu = context.ScheduleStatus.Find(schedule.statusId);
                        context.Schedules.Add(schedule);
                        context.SaveChanges();
                   
                }
            }

            // Return false if customeredit == null or CustomerID is not a guid
            return null;
        }

        //END SCHEDULE LIST
    }
}