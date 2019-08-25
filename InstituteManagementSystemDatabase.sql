﻿--create table ADDRESSMASTER
--(
--	ADDRESSID int primary key identity(1,1),
--	HOMEADDRESS varchar not null
--);

--create table SUBJECTMASTER
--(
--	SUBJECTID int primary key identity(1,1),
--	SUBJECTNAME varchar not null
--);

--create table DESIGNATIONMASTER
--(
--	DESIGNATIONID int primary key identity(1,1),
--	DESIGNATION varchar not null
--);

--create table CLASSMASTER
--(
--	CLASSID int primary key identity(1,1),
--	CLASS varchar not null
--);

--create table CONTACTMASTER
--(
--	CONTACTID int primary key identity(1,1),
--	CONTACT1 varchar not null,
--	CONTACT2 varchar
--);

--create table USERMASTER
--(
--	USERID int primary key identity(1,1),
--	FULLNAME varchar not null,
--	USERDESIGNATIONID int foreign key references DESIGNATIONMASTER(DESIGNATIONID),
--	CONTACTDETAILS int foreign key references CONTACTMASTER(CONTACTID),
--	QUALIFICATION varchar not null,
--	TOTALPAYMENT varchar not null,
--	PAYMENTDATE date not null,
--	JOININGDATE date not null,
--	WORKTYPE varchar not null,
--	BATCH varchar not null,
--	ISUSERACTIVE bit default 'false'
--);

--create table STUDENTMASTER
--(
--	STUDENTID int primary key identity(1,1),
--	FIRSTNAME varchar not null,
--	MIDDLENAME varchar not null,
--	LASTNAME varchar not null,
--	DATEOFBIRTH date not null,
--	STUDENTCLASSID int foreign key references CLASSMASTER(CLASSID),
--	STUDENTSUBJECTIDS varchar not null,
--	SCHOOL varchar not null,
--	GENDER varchar not null,
--	STUDENTADDRESSID int foreign key references ADDRESSMASTER(ADDRESSID),
--	STUDENTCONTACTID int foreign key references CONTACTMASTER(CONTACTID),
--	TOTALFEES bigint not null,
--	NUMBEROFINSTALLMENTS int not null,
--	DATEOFADMISSION date not null,
--	ISSTUDENTACTIVE bit default 'true',
--	ISSTUDENTPASSES bit default 'false',
--	DATEOFPASSING date not null
--);

--create table FEESMASTER
--(
--	FEESID int primary key identity(1,1),
--	FEESSTUDENTID int foreign key references STUDENTMASTER(STUDENTID),
--	TOTALFEES bigint not null,
--	FEESPAID bigint not null,
--	FEESBALANCE bigint,
--	FEESPAIDDATE date  not null,
--	FEESFEESDETAILSID int foreign key references FEESDETAILS(FEESDETAILSID)
--)

--create table FEESDETAILS
--(
--	FEESDETAILSID int primary key identity(1,1),
--	FEESDETAILSSTUDENTID int foreign key references STUDENTMASTER(STUDENTID),
--	TOTALFEES bigint not null,
--	FEESPAID bigint not null,
--	FEESBALANCE bigint,
--	FEESPAIDDATE date not null,
--	RECEIVEDBY varchar not null
--);