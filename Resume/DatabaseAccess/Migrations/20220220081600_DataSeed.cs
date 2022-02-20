using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace DatabaseAccess.Migrations
{
    public partial class DataSeed : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {

            //Seed Constants for foreign key constraints
            migrationBuilder.Sql(@"
                                    INSERT INTO 'main'.'UserType'('Id','Type')VALUES(1,'User');
                                    INSERT INTO 'main'.'UserType'('Id','Type')VALUES(2,'Admin');
                                    INSERT INTO 'main'.'PositionType'('Id','Type')VALUES(1,'Paid');
                                    INSERT INTO 'main'.'PositionType'('Id','Type')VALUES(2,'Volunteer');
            ");

            //Seed database records
            migrationBuilder.Sql(@"
                                    INSERT INTO 'main'.'EndUser'('Id','Email','Password','UserTypeId')VALUES(1,'admin@wdresu.me','$argon2id$v=19$m=65536,t=3,p=1$2uWVtvZs79eRtPMBQ6SRqw$fZvAZFZg3xLN71DkdeH4isuCXY/c7HOA/LKvsSvgXCM',2);
                                    INSERT INTO 'main'.'EndUser'('Id','Email','Password','UserTypeId')VALUES(2,'user@wdresu.me','$argon2id$v=19$m=65536,t=3,p=1$JRLPlSMQW0Qbk2yJFNAIAg$7br9Jv6Oi/g9hELPkO9AeUPaiMaGCwTF3AMGdXQaVhM',1);                               
                                    INSERT INTO 'main'.'Candidate'('EndUserId','FirstName','LastName','City','State','PostCode','Country','Phone','CountryOfBirth','Citizenship','DateOfBirth')VALUES(2,'William','Douglas','Joondalup','WA','6027','Australia','0416 019 882','Australia','Australian Citizen','1988-05-20 00:00:00');
                                    INSERT INTO 'main'.'Position'('Id','Name','Organisation','StartDate','CandidateId','PositionTypeId')VALUES(1,'Software Developer','Industrial Automation Group','2021-07-02 00:00:00',2,1);
                                    INSERT INTO 'main'.'Position'('Id','Name','Organisation','StartDate','EndDate','CandidateId','PositionTypeId')VALUES(2,'Operational Support','CNW Electrical Wholesale','2019-07-01','2021-06-30 00:00:00',2,1);
                                    INSERT INTO 'main'.'Position'('Id','Name','Organisation','StartDate','EndDate','CandidateId','PositionTypeId')VALUES(3,'National Systems Trainer','BGW Group','2015-02-09','2019-06-28 00:00:00',2,1);
                                    INSERT INTO 'main'.'Position'('Id','Name','Organisation','StartDate','EndDate','CandidateId','PositionTypeId')VALUES(4,'Sales/Operations','CNW Electrical Wholesale - Wangara','2011-04-29','2015-02-06 00:00:00',2,1);
                                    INSERT INTO 'main'.'Position'('Id','Name','Organisation','StartDate','EndDate','CandidateId','PositionTypeId')VALUES(5,'Director','CoderKidz','2016-07-01','2018-07-01 00:00:00.00',2,2);
                                    INSERT INTO 'main'.'Position'('Id','Name','Organisation','StartDate','EndDate','CandidateId','PositionTypeId')VALUES(6,'Mentor','CoderDojo Brisbane','2015-07-01','2016-06-30 00:00:00',2,2);
                                    INSERT INTO 'main'.'Position'('Id','Name','Organisation','StartDate','EndDate','CandidateId','PositionTypeId')VALUES(7,'Acting Coordinator','CoderDojo WA','2014-10-13','2014-10-31 00:00:00',2,2);
                                    INSERT INTO 'main'.'Position'('Id','Name','Organisation','StartDate','EndDate','CandidateId','PositionTypeId')VALUES(8,'Lead Mentor','CoderDojo WA','2014-02-01','2014-11-30 00:00:00',2,2);
                                    INSERT INTO 'main'.'Responsibility'('Name','Description','PositionId')VALUES('Development','Researching, Developing and Integrating new services and technologies into the existing tech stack',1);
                                    INSERT INTO 'main'.'Responsibility'('Name','Description','PositionId')VALUES('Maintenance','Maintaining the existing .NET SCADA web project which provides access to and oversight of the field devices',1);
                                    INSERT INTO 'main'.'Responsibility'('Name','Description','PositionId')VALUES('Support','Providing technical and networking support when required',1);
                                    INSERT INTO 'main'.'Responsibility'('Name','Description','PositionId')VALUES('Training','Preparing training videos for system users',1);
                                    INSERT INTO 'main'.'Responsibility'('Name','Description','PositionId')VALUES('Training','Providing on site training to new and existing staff for system use and business practices',2);
                                    INSERT INTO 'main'.'Responsibility'('Name','Description','PositionId')VALUES('Support','Providing operational support and guidance to business and regional managers as required',2);
                                    INSERT INTO 'main'.'Responsibility'('Name','Description','PositionId')VALUES('Training','Providing remote and on site training to new and existing staff for system use and business practices',3);
                                    INSERT INTO 'main'.'Responsibility'('Name','Description','PositionId')VALUES('Support','Providing operational support and guidance to business and regional managers as required',3);
                                    INSERT INTO 'main'.'Responsibility'('Name','Description','PositionId')VALUES('Material','Development and Maintenance of training material and user help guides',3);
                                    INSERT INTO 'main'.'Responsibility'('Name','Description','PositionId')VALUES('System','Scoping and Testing of system changes and upgrades',3);
                                    INSERT INTO 'main'.'Responsibility'('Name','Description','PositionId')VALUES('Sales','Sales and customer service',4);
                                    INSERT INTO 'main'.'Responsibility'('Name','Description','PositionId')VALUES('Operations','Miscellaneous operational support',4);
                                    INSERT INTO 'main'.'Responsibility'('Name','Description','PositionId')VALUES('Purchasing','Purchasing and procurement',4);
                                    INSERT INTO 'main'.'Responsibility'('Name','Description','PositionId')VALUES('CoderDojo','Coordination of the CoderDojo Brisbane program in partnership with Brisbane Marketing',5);
                                    INSERT INTO 'main'.'Responsibility'('Name','Description','PositionId')VALUES('Material','Preparation of learning material and courses for program delivery',5);
                                    INSERT INTO 'main'.'Responsibility'('Name','Description','PositionId')VALUES('Mentoring','Delivery of educational material in programming, electronics and robotics to kids and teenagers 7-17',5);
                                    INSERT INTO 'main'.'Responsibility'('Name','Description','PositionId')VALUES('Material','Preparation of learning material and courses for program delivery',6);
                                    INSERT INTO 'main'.'Responsibility'('Name','Description','PositionId')VALUES('Mentoring','Delivery of educational material in programming to kids and teenagers 7-17',6);
                                    INSERT INTO 'main'.'Responsibility'('Name','Description','PositionId')VALUES('Coordination','Coordinating the CoderDojo WA program. Liaising with Mentors and external parties to guarantee availability of resources and volunteers',7);
                                    INSERT INTO 'main'.'Responsibility'('Name','Description','PositionId')VALUES('Research','Research and preparation of strategies and vectors for program expansion into regional communities',7);
                                    INSERT INTO 'main'.'Responsibility'('Name','Description','PositionId')VALUES('Material','Preparation of learning material and courses for program delivery',8);
                                    INSERT INTO 'main'.'Responsibility'('Name','Description','PositionId')VALUES('Mentoring','Delivery of educational material in programming to kids and teenagers 7-17',8);
                                    INSERT INTO 'main'.'Responsibility'('Name','Description','PositionId')VALUES('Coordination','Liaising with external parties and volunteers to guarantee availability of resources',8);
                                    INSERT INTO 'main'.'Project'('Id','Name','Description','CandidateId')VALUES('1','Tvilight','Integration of Tvilight API into existing SCADA project for streetlight control using IOT enabled controllers',2);
                                    INSERT INTO 'main'.'Project'('Id','Name','Description','CandidateId')VALUES('2','FMC130','Development of program and library for communication with Teltonika FMC130 vehicle trackers',2);
                                    INSERT INTO 'main'.'Project'('Id','Name','Description','CandidateId')VALUES('3','MQTTMobile','Extension of existing mobile access functionality to allow communication with newer PLCs using the MQTT protocol',2);
                                    INSERT INTO 'main'.'Project'('Id','Name','Description','CandidateId')VALUES('4','QOL','Various customer requested and Quality of Life improvements to existing SCADA projects',2);
                                    INSERT INTO 'main'.'ProjectOutcome'('Description','ProjectId')VALUES('Integration with Tvilight REST API and development of library for data structures and methods to facilitate calls',1);
                                    INSERT INTO 'main'.'ProjectOutcome'('Description','ProjectId')VALUES('Creation and integration of front end controls and back end logic to handle setting up lighting schedules for streetlight controls',1);
                                    INSERT INTO 'main'.'ProjectOutcome'('Description','ProjectId')VALUES('Testing and troubleshooting for QA purposes prior to deployment to production environment',1);
                                    INSERT INTO 'main'.'ProjectOutcome'('Description','ProjectId')VALUES('Creation of basic TCP listener console app to receive data from vehicle tracker',2);
                                    INSERT INTO 'main'.'ProjectOutcome'('Description','ProjectId')VALUES('Set up and negotiation of comms from vehicle tracker to listener app through network firewalls and VPN',2);
                                    INSERT INTO 'main'.'ProjectOutcome'('Description','ProjectId')VALUES('Creation (from scratch) of library for decoding variable size data payloads in Codec8 protocol',2);
                                    INSERT INTO 'main'.'ProjectOutcome'('Description','ProjectId')VALUES('Creation and integration of additional controls to facilitate live communications with field devices via MQTT protocol',3);
                                    INSERT INTO 'main'.'ProjectOutcome'('Description','ProjectId')VALUES('Modification of existing controls to facilitate integration of new workflow',3);
                                    INSERT INTO 'main'.'ProjectOutcome'('Description','ProjectId')VALUES('Integration with paypal API to facilitate payment from non registered users',3);
                                    INSERT INTO 'main'.'ProjectOutcome'('Description','ProjectId')VALUES('Testing and troubleshooting for QA purposes prior to deployment to production environment',3);
                                    INSERT INTO 'main'.'ProjectOutcome'('Description','ProjectId')VALUES('Integration of bulk email feature for user organisations. Addition of user filters',4);
                                    INSERT INTO 'main'.'ProjectOutcome'('Description','ProjectId')VALUES('Significant refactor of relationships between database entities to improve data integrity',4);
                                    INSERT INTO 'main'.'ProjectOutcome'('Description','ProjectId')VALUES('Implementation of back end services for various long running tasks',4);
                                    INSERT INTO 'main'.'Course'('Name','School','Qualification','Completed','CandidateId','CommencedDate','CompletionDate')VALUES('Software Development','North Metropolitan TAFE - Joondalup Campus','Diploma',TRUE,2,'2020-02-03 00:00:00','2021-07-02 00:00:00');
                                    INSERT INTO 'main'.'Course'('Name','School','Qualification','Completed','CandidateId','CommencedDate')VALUES('Electrical & Electronic Engineering','North Metropolitan TAFE - East Perth Campus','Diploma',False,2,'2008-02-01 00:00:00');
                                    INSERT INTO 'main'.'Course'('Name','School','Qualification','Completed','CandidateId','CommencedDate')VALUES('Physics','Curtin University of Technology - Bentley Campus','Bachelors Degree',False,2,'2006-03-01 00:00:00');
                                    INSERT INTO 'main'.'Skill'('Description','CandidateId')VALUES('Significant progamming experience from volunteer roles across a range of languages, primarily web languages such as HTML and JS',2);
                                    INSERT INTO 'main'.'Skill'('Description','CandidateId')VALUES('Professional experience with C# using the .NET and .NET Core frameworks, and with JS using the Jquery framework',2);
                                    INSERT INTO 'main'.'Skill'('Description','CandidateId')VALUES('Experience with REST API integration',2);
                                    INSERT INTO 'main'.'Skill'('Description','CandidateId')VALUES('Experience in Leadership and Management roles',2);
                                    INSERT INTO 'main'.'Skill'('Description','CandidateId')VALUES('Strong problem solving and analytical skills',2);
                                    INSERT INTO 'main'.'Skill'('Description','CandidateId')VALUES('Strong customer service skills and experience in training and consulting positions',2);
                                    INSERT INTO 'main'.'Skill'('Description','CandidateId')VALUES('Able to work productively and cooperatively in team environments',2);
                                ");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {

        }
    }
}
