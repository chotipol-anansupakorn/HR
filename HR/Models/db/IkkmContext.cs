using System;
using System.Collections.Generic;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata;

namespace HR.Models.db
{
    public partial class IkkmContext : DbContext
    {
        public IkkmContext()
        {
        }

        public IkkmContext(DbContextOptions<IkkmContext> options)
            : base(options)
        {
        }

        public virtual DbSet<Department> Departments { get; set; } = null!;
        public virtual DbSet<District> Districts { get; set; } = null!;
        public virtual DbSet<EmpBoss> EmpBosses { get; set; } = null!;
        public virtual DbSet<EmpChild> EmpChildren { get; set; } = null!;
        public virtual DbSet<EmpContact> EmpContacts { get; set; } = null!;
        public virtual DbSet<EmpLeave> EmpLeaves { get; set; } = null!;
        public virtual DbSet<EmpOt> EmpOts { get; set; } = null!;
        public virtual DbSet<EmpSlibing> EmpSlibings { get; set; } = null!;
        public virtual DbSet<EmpTimestamp> EmpTimestamps { get; set; } = null!;
        public virtual DbSet<Employee> Employees { get; set; } = null!;
        public virtual DbSet<Gender> Genders { get; set; } = null!;
        public virtual DbSet<Holiday> Holidays { get; set; } = null!;
        public virtual DbSet<Leave> Leaves { get; set; } = null!;
        public virtual DbSet<MarryStatus> MarryStatuses { get; set; } = null!;
        public virtual DbSet<Ot> Ots { get; set; } = null!;
        public virtual DbSet<Position> Positions { get; set; } = null!;
        public virtual DbSet<Province> Provinces { get; set; } = null!;
        public virtual DbSet<Subdistrict> Subdistricts { get; set; } = null!;
        public virtual DbSet<WorkingPeriod> WorkingPeriods { get; set; } = null!;
        public virtual DbSet<WorkingShift> WorkingShifts { get; set; } = null!;
        public virtual DbSet<Zipcode> Zipcodes { get; set; } = null!;

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            if (!optionsBuilder.IsConfigured)
            {
                IConfigurationRoot configuration = new ConfigurationBuilder()
                .SetBasePath(Directory.GetCurrentDirectory())
                .AddJsonFile("appsettings.json")
                .Build();
                var connectionString = configuration.GetConnectionString("HRServer");
                optionsBuilder.UseSqlServer(connectionString);
            }
        }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<Department>(entity =>
            {
                entity.ToTable("department");

                entity.Property(e => e.DepartmentId).HasColumnName("departmentID");

                entity.Property(e => e.DeparmentBossId).HasColumnName("deparmentBossID");

                entity.Property(e => e.DepartmentName)
                    .HasMaxLength(150)
                    .IsUnicode(false)
                    .HasColumnName("departmentName");
            });

            modelBuilder.Entity<District>(entity =>
            {
                entity.ToTable("district");

                entity.Property(e => e.Id).HasColumnName("id");

                entity.Property(e => e.DistrictName).HasColumnName("districtName");

                entity.Property(e => e.ProvinceId).HasColumnName("provinceId");
            });

            modelBuilder.Entity<EmpBoss>(entity =>
            {
                entity.ToTable("empBoss");

                entity.Property(e => e.Id).HasColumnName("id");

                entity.Property(e => e.BossId)
                    .HasMaxLength(7)
                    .HasColumnName("BossID");

                entity.Property(e => e.EmpId)
                    .HasMaxLength(7)
                    .HasColumnName("empID");

                entity.HasOne(d => d.Emp)
                    .WithMany(p => p.EmpBosses)
                    .HasForeignKey(d => d.EmpId)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("FK_empSubordinate_employee");
            });

            modelBuilder.Entity<EmpChild>(entity =>
            {
                entity.ToTable("empChild");

                entity.Property(e => e.Id).HasColumnName("id");

                entity.Property(e => e.EmpChildDob)
                    .HasColumnType("date")
                    .HasColumnName("empChildDOB");

                entity.Property(e => e.EmpChildName)
                    .HasMaxLength(50)
                    .HasColumnName("empChildName");

                entity.Property(e => e.EmpChildSurname)
                    .HasMaxLength(75)
                    .HasColumnName("empChildSurname");

                entity.Property(e => e.EmpId)
                    .HasMaxLength(7)
                    .HasColumnName("empID");

                entity.HasOne(d => d.Emp)
                    .WithMany(p => p.EmpChildren)
                    .HasForeignKey(d => d.EmpId)
                    .HasConstraintName("FK_empChild_Id");
            });

            modelBuilder.Entity<EmpContact>(entity =>
            {
                entity.ToTable("empContact");

                entity.Property(e => e.Id).HasColumnName("id");

                entity.Property(e => e.EmergencyContactName)
                    .HasMaxLength(50)
                    .HasColumnName("emergencyContactName");

                entity.Property(e => e.EmergencyContactRelation)
                    .HasMaxLength(50)
                    .HasColumnName("emergencyContactRelation");

                entity.Property(e => e.EmergencyContactSurname)
                    .HasMaxLength(75)
                    .HasColumnName("emergencyContactSurname");

                entity.Property(e => e.EmergencyContactTel)
                    .HasMaxLength(50)
                    .HasColumnName("emergencyContactTel");

                entity.Property(e => e.EmpDadDob)
                    .HasColumnType("date")
                    .HasColumnName("empDadDOB");

                entity.Property(e => e.EmpDadJob)
                    .HasMaxLength(100)
                    .HasColumnName("empDadJob");

                entity.Property(e => e.EmpDadName)
                    .HasMaxLength(50)
                    .HasColumnName("empDadName");

                entity.Property(e => e.EmpDadSurname)
                    .HasMaxLength(75)
                    .HasColumnName("empDadSurname");

                entity.Property(e => e.EmpDadTel)
                    .HasMaxLength(50)
                    .HasColumnName("empDadTel");

                entity.Property(e => e.EmpId)
                    .HasMaxLength(7)
                    .HasColumnName("empID");

                entity.Property(e => e.EmpMomDob)
                    .HasColumnType("date")
                    .HasColumnName("empMomDOB");

                entity.Property(e => e.EmpMomJob)
                    .HasMaxLength(100)
                    .HasColumnName("empMomJob");

                entity.Property(e => e.EmpMomName)
                    .HasMaxLength(50)
                    .HasColumnName("empMomName");

                entity.Property(e => e.EmpMomSurname)
                    .HasMaxLength(75)
                    .HasColumnName("empMomSurname");

                entity.Property(e => e.EmpMomTel)
                    .HasMaxLength(50)
                    .HasColumnName("empMomTel");

                entity.Property(e => e.EmpSpouseDob)
                    .HasColumnType("date")
                    .HasColumnName("empSpouseDOB");

                entity.Property(e => e.EmpSpouseJob)
                    .HasMaxLength(100)
                    .HasColumnName("empSpouseJob");

                entity.Property(e => e.EmpSpouseName)
                    .HasMaxLength(50)
                    .HasColumnName("empSpouseName");

                entity.Property(e => e.EmpSpouseSurname)
                    .HasMaxLength(75)
                    .HasColumnName("empSpouseSurname");

                entity.Property(e => e.EmpSpouseTel)
                    .HasMaxLength(50)
                    .HasColumnName("empSpouseTel");

                entity.HasOne(d => d.Emp)
                    .WithMany(p => p.EmpContacts)
                    .HasForeignKey(d => d.EmpId)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("FK_empContact_Id");
            });

            modelBuilder.Entity<EmpLeave>(entity =>
            {
                entity.ToTable("empLeave");

                entity.Property(e => e.Id).HasColumnName("id");

                entity.Property(e => e.ApproveBy)
                    .HasMaxLength(7)
                    .HasColumnName("approveBy");

                entity.Property(e => e.EmpId)
                    .HasMaxLength(7)
                    .HasColumnName("empID");

                entity.Property(e => e.LeaveId).HasColumnName("leaveID");

                entity.Property(e => e.LeaveStart)
                    .HasColumnType("datetime")
                    .HasColumnName("leaveStart");

                entity.Property(e => e.LeaveStop)
                    .HasColumnType("datetime")
                    .HasColumnName("leaveStop");

                entity.Property(e => e.RegistDateTime)
                    .IsRowVersion()
                    .IsConcurrencyToken()
                    .HasColumnName("registDateTime");

                entity.HasOne(d => d.Emp)
                    .WithMany(p => p.EmpLeaves)
                    .HasForeignKey(d => d.EmpId)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("FK_empLeave_empLeave");
            });

            modelBuilder.Entity<EmpOt>(entity =>
            {
                entity.ToTable("empOT");

                entity.Property(e => e.Id)
                    .ValueGeneratedNever()
                    .HasColumnName("id");

                entity.Property(e => e.ApproveBy)
                    .HasMaxLength(7)
                    .HasColumnName("approveBy");

                entity.Property(e => e.EmpId)
                    .HasMaxLength(7)
                    .HasColumnName("empID");

                entity.Property(e => e.OtDate)
                    .HasColumnType("date")
                    .HasColumnName("OT_Date");

                entity.Property(e => e.OtId).HasColumnName("OT_id");

                entity.Property(e => e.OtStart).HasColumnName("OT_Start");

                entity.Property(e => e.OtStop).HasColumnName("OT_Stop");

                entity.Property(e => e.RegistDateTime)
                    .HasColumnType("datetime")
                    .HasColumnName("registDateTime");

                entity.HasOne(d => d.Emp)
                    .WithMany(p => p.EmpOts)
                    .HasForeignKey(d => d.EmpId)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("FK_empOT_employee");
            });

            modelBuilder.Entity<EmpSlibing>(entity =>
            {
                entity.ToTable("empSlibing");

                entity.Property(e => e.Id).HasColumnName("id");

                entity.Property(e => e.EmpId)
                    .HasMaxLength(7)
                    .HasColumnName("empID");

                entity.Property(e => e.EmpSlibingDob)
                    .HasColumnType("date")
                    .HasColumnName("empSlibingDOB");

                entity.Property(e => e.EmpSlibingJob)
                    .HasMaxLength(100)
                    .HasColumnName("empSlibingJob");

                entity.Property(e => e.EmpSlibingName)
                    .HasMaxLength(50)
                    .HasColumnName("empSlibingName");

                entity.Property(e => e.EmpSlibingSurname)
                    .HasMaxLength(75)
                    .HasColumnName("empSlibingSurname");

                entity.Property(e => e.EmpSlibingTel)
                    .HasMaxLength(50)
                    .HasColumnName("empSlibingTel");

                entity.HasOne(d => d.Emp)
                    .WithMany(p => p.EmpSlibings)
                    .HasForeignKey(d => d.EmpId)
                    .HasConstraintName("FK_empSlibing_Id");
            });

            modelBuilder.Entity<EmpTimestamp>(entity =>
            {
                entity.ToTable("empTimestamp");

                entity.Property(e => e.Id).HasColumnName("id");

                entity.Property(e => e.EmpId)
                    .HasMaxLength(7)
                    .HasColumnName("empID");

                entity.Property(e => e.TimeIn)
                    .HasColumnType("datetime")
                    .HasColumnName("timeIn");

                entity.Property(e => e.TimeOut)
                    .HasColumnType("datetime")
                    .HasColumnName("timeOut");

                entity.HasOne(d => d.Emp)
                    .WithMany(p => p.EmpTimestamps)
                    .HasForeignKey(d => d.EmpId)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("FK_empTimestamp_employee");
            });

            modelBuilder.Entity<Employee>(entity =>
            {
                entity.HasKey(e => e.EmpId);

                entity.ToTable("employee");

                entity.HasIndex(e => e.EmpIdno, "IX_empIDNo")
                    .IsUnique();

                entity.Property(e => e.EmpId)
                    .HasMaxLength(7)
                    .HasColumnName("empID");

                entity.Property(e => e.BaseSalary).HasColumnName("baseSalary");

                entity.Property(e => e.Bod)
                    .HasColumnType("date")
                    .HasColumnName("bod");

                entity.Property(e => e.District).HasColumnName("district");

                entity.Property(e => e.EmpCurrentAddress).HasColumnName("empCurrentAddress");

                entity.Property(e => e.EmpDepartmentId).HasColumnName("empDepartmentID");

                entity.Property(e => e.EmpEmail)
                    .HasMaxLength(150)
                    .HasColumnName("empEmail");

                entity.Property(e => e.EmpEnd)
                    .HasColumnType("date")
                    .HasColumnName("empEnd");

                entity.Property(e => e.EmpGenderId).HasColumnName("empGenderID");

                entity.Property(e => e.EmpIdcardAddress).HasColumnName("empIDCardAddress");

                entity.Property(e => e.EmpIdno)
                    .HasMaxLength(50)
                    .HasColumnName("empIDNo");

                entity.Property(e => e.EmpImage).HasColumnName("empImage");

                entity.Property(e => e.EmpJobName)
                    .HasMaxLength(50)
                    .HasColumnName("empJobName");

                entity.Property(e => e.EmpMarrySatatusId).HasColumnName("empMarrySatatusID");

                entity.Property(e => e.EmpName)
                    .HasMaxLength(50)
                    .HasColumnName("empName");

                entity.Property(e => e.EmpPositionId).HasColumnName("empPositionID");

                entity.Property(e => e.EmpStart)
                    .HasColumnType("date")
                    .HasColumnName("empStart");

                entity.Property(e => e.EmpSurname)
                    .HasMaxLength(75)
                    .HasColumnName("empSurname");

                entity.Property(e => e.EmpTel)
                    .HasMaxLength(50)
                    .HasColumnName("empTel");

                entity.Property(e => e.Id)
                    .ValueGeneratedOnAdd()
                    .HasColumnName("id");

                entity.Property(e => e.IsDelete)
                    .HasColumnName("isDelete")
                    .HasDefaultValueSql("((0))");

                entity.Property(e => e.Probation).HasColumnName("probation");

                entity.Property(e => e.Province).HasColumnName("province");

                entity.Property(e => e.RegistBy)
                    .HasMaxLength(7)
                    .HasColumnName("registBy");

                entity.Property(e => e.RegistDateTime)
                    .HasColumnType("datetime")
                    .HasColumnName("registDateTime")
                    .HasDefaultValueSql("(getdate())");

                entity.Property(e => e.SkillSalary).HasColumnName("skillSalary");

                entity.Property(e => e.SubDistrict).HasColumnName("subDistrict");

                entity.Property(e => e.WorkingHrsId).HasColumnName("workingHrsID");

                entity.Property(e => e.Zipcode).HasColumnName("zipcode");
            });

            modelBuilder.Entity<Gender>(entity =>
            {
                entity.ToTable("gender");

                entity.Property(e => e.GenderId).HasColumnName("genderID");

                entity.Property(e => e.GenderName)
                    .HasMaxLength(10)
                    .HasColumnName("genderName");
            });

            modelBuilder.Entity<Holiday>(entity =>
            {
                entity.HasNoKey();

                entity.ToTable("holiday");

                entity.Property(e => e.HolidayDate)
                    .HasColumnType("date")
                    .HasColumnName("holidayDate");

                entity.Property(e => e.HolidayId)
                    .ValueGeneratedOnAdd()
                    .HasColumnName("holidayID");

                entity.Property(e => e.HolidayName).HasColumnName("holidayName");
            });

            modelBuilder.Entity<Leave>(entity =>
            {
                entity.ToTable("leave");

                entity.Property(e => e.LeaveId).HasColumnName("leaveID");

                entity.Property(e => e.LeaveDays).HasColumnName("leaveDays");

                entity.Property(e => e.LeaveType)
                    .HasMaxLength(50)
                    .HasColumnName("leaveType");
            });

            modelBuilder.Entity<MarryStatus>(entity =>
            {
                entity.ToTable("marryStatus");

                entity.Property(e => e.MarryStatusId).HasColumnName("marryStatusID");

                entity.Property(e => e.MarryStatus1)
                    .HasMaxLength(50)
                    .HasColumnName("marryStatus");
            });

            modelBuilder.Entity<Ot>(entity =>
            {
                entity.ToTable("OT");

                entity.Property(e => e.OtId).HasColumnName("OT_ID");

                entity.Property(e => e.OtMutiple).HasColumnName("OT_mutiple");
            });

            modelBuilder.Entity<Position>(entity =>
            {
                entity.ToTable("position");

                entity.Property(e => e.PositionId).HasColumnName("positionID");

                entity.Property(e => e.PositionName)
                    .HasMaxLength(100)
                    .HasColumnName("positionName");
            });

            modelBuilder.Entity<Province>(entity =>
            {
                entity.ToTable("province");

                entity.Property(e => e.Id).HasColumnName("id");

                entity.Property(e => e.ProvinceName).HasColumnName("provinceName");
            });

            modelBuilder.Entity<Subdistrict>(entity =>
            {
                entity.ToTable("subdistrict");

                entity.Property(e => e.Id).HasColumnName("id");

                entity.Property(e => e.DistrictId).HasColumnName("districtId");

                entity.Property(e => e.SubdistrictName).HasColumnName("subdistrictName");
            });

            modelBuilder.Entity<WorkingPeriod>(entity =>
            {
                entity.HasKey(e => e.WorkingHrsId);

                entity.ToTable("workingPeriod");

                entity.Property(e => e.WorkingHrsId).HasColumnName("workingHrsID");

                entity.Property(e => e.WorkingStartTime)
                    .HasColumnType("time(4)")
                    .HasColumnName("workingStartTime");

                entity.Property(e => e.WorkingStopTime)
                    .HasColumnType("time(4)")
                    .HasColumnName("workingStopTime");
            });

            modelBuilder.Entity<WorkingShift>(entity =>
            {
                entity.HasKey(e => e.ShiftId);

                entity.ToTable("workingShift");

                entity.Property(e => e.ShiftId).HasColumnName("shiftID");

                entity.Property(e => e.EmpId).HasColumnName("empID");

                entity.Property(e => e.RegistDateTime)
                    .HasColumnType("datetime")
                    .HasColumnName("registDateTime");

                entity.Property(e => e.ShiftStartDate)
                    .HasColumnType("datetime")
                    .HasColumnName("shiftStartDate");

                entity.Property(e => e.ShiftStopDate)
                    .HasColumnType("datetime")
                    .HasColumnName("shiftStopDate");

                entity.Property(e => e.WorkingHrsId).HasColumnName("workingHrsID");
            });

            modelBuilder.Entity<Zipcode>(entity =>
            {
                entity.ToTable("zipcode");

                entity.Property(e => e.Id).HasColumnName("id");

                entity.Property(e => e.SubdistrictId).HasColumnName("subdistrictId");

                entity.Property(e => e.ZipcodeName)
                    .HasMaxLength(5)
                    .HasColumnName("zipcodeName");
            });

            OnModelCreatingPartial(modelBuilder);
        }

        partial void OnModelCreatingPartial(ModelBuilder modelBuilder);
    }
}
