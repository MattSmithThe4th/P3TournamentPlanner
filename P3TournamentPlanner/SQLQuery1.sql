﻿use GeneralDatabase;

select * from TeamsDB;
select * from ClubManagerDB;
select teamName, managerID, divisionID from TeamsDB;
select tlfNumber from ContactInfoDB where userID='HVMan1';

--Creating the relevant tables
create table TeamsDB(teamID int primary key identity, clubID int, divisionID int, leagueID int, teamName varchar(64), teamRating int, placement int, matchPlayed int, matchesWon int, matchesDraw int, matchesLost int, roundsWon int, roundsLost int, points int, managerID varchar(64), archiveFlag int);
create table DivisionsDB(divisionID int, leagueID int, divisionFormat varchar(64), archiveFlag int);
create table LeagueDB(leagueID int primary key identity, leagueName varchar(64), game varchar(64), adminID varchar(64), archiveFlag int);
create table PlayerDB(teamID int, clubID int, IRLName varchar(64), IGName varchar(64), steamID varchar(64), csgoRank varchar(64), skillRating int);
create table ClubDB(clubID int primary key identity, clubName varchar(64), clubAddress varchar(64));
create table ClubManagerDB(clubID int, userID varchar(64));
create table ContactInfoDB(userID varchar(64), contactName varchar(64), tlfNumber varchar(16), discordID varchar(64), email varchar(64))
create table MatchDB(matchID int primary key identity, divisionID int, leagueID int, team1ID int, team2ID int, team1Score int, team2Score int, startTime varchar(64), playedFlag int, hostClubID int, serverIP varchar(64))

--select * from TeamsDB

--Creating Clubs
insert into ClubDB(clubName, clubAddress) values ('Hobro Vikings', 'Amerikavej 22, 9500 Hobro')
insert into ClubDB(clubName, clubAddress) values ('Dall Villaby', 'Klokkevej 49, 9230 Svenstrup J')

--Creating Club Managers
insert into ClubManagerDB(clubID, userID) values (1, 'HVMan1')
insert into ClubManagerDB(clubID, userID) values (1, 'HVMan2')
insert into ClubManagerDB(clubID, userID) values (2, 'DVMan1')


--Creating Contct Info
insert into ContactInfoDB(userID, contactName, tlfNumber, discordID, email) values ('HVMan1', 'Martin Svanholm', '23276132', 'mrsvanholm#0007', 'mart373e@gmail.com')
insert into ContactInfoDB(userID, contactName, tlfNumber, discordID, email) values ('HVMan2', 'Brian Svanholm', '12345678', 'DetteErEtDiscordNavn#1234', 'eksempel@mail.com')
insert into ContactInfoDB(userID, contactName, tlfNumber, discordID, email) values ('DVMan1', 'Stålkat Svanholm', '87654321', 'Stålkat#4321', 'stålkat@gmail.com')

--Creating Teams
insert into TeamsDB(clubID, divisionID, leagueID, teamName, teamRating, placement, matchPlayed, matchesWon, matchesDraw, matchesLost, roundsWon, roundsLost, points, managerID, archiveFlag) values(1, 1, 1, 'Hobro Vikings - Hold 1', 420, 2, 5, 3, 1, 1, 55, 25, 10, 'HVMan1', 0)
insert into TeamsDB(clubID, divisionID, leagueID, teamName, teamRating, placement, matchPlayed, matchesWon, matchesDraw, matchesLost, roundsWon, roundsLost, points, managerID, archiveFlag) values(1, 2, 1, 'Hobro Vikings - Hold 2', 415, 2, 5, 1, 1, 3, 25, 55, 4, 'HVMan2', 0)
insert into TeamsDB(clubID, divisionID, leagueID, teamName, teamRating, placement, matchPlayed, matchesWon, matchesDraw, matchesLost, roundsWon, roundsLost, points, managerID, archiveFlag) values(2, 1, 1, 'Dall Villaby - Hold 1', 312, 1, 6, 2, 0, 4, 24, 56, 6, 'DVMan1', 0)
insert into TeamsDB(clubID, divisionID, leagueID, teamName, teamRating, placement, matchPlayed, matchesWon, matchesDraw, matchesLost, roundsWon, roundsLost, points, managerID, archiveFlag) values(2, 2, 1, 'Dall Villaby - Hold 2', 300, 1, 5, 1, 1, 3, 25, 55, 4, 'DVMan1', 0)

--Creating Players
--Hobro Vikings - Hold 1
insert into PlayerDB(teamID, clubID, IRLName, IGName, steamID, csgoRank, skillRating) values (1, 1, 'Jonas', '1onas', 'STEAM_0:0:11101', 'Silver 1', 1)
insert into PlayerDB(teamID, clubID, IRLName, IGName, steamID, csgoRank, skillRating) values (1, 1, 'Terkel', 't3r3l', 'STEAM_0:0:11102', 'Silver 2', 2)
insert into PlayerDB(teamID, clubID, IRLName, IGName, steamID, csgoRank, skillRating) values (1, 1, 'Marie', 'Mar1e', 'STEAM_0:0:11103', 'Silver 3', 3)
insert into PlayerDB(teamID, clubID, IRLName, IGName, steamID, csgoRank, skillRating) values (1, 1, 'Buster', 'BeastBubber', 'STEAM_0:0:11104', 'Silver 4', 4)
insert into PlayerDB(teamID, clubID, IRLName, IGName, steamID, csgoRank, skillRating) values (1, 1, 'Emil', 'xX_EmilGamer_Xx', 'STEAM_0:0:11105', 'Silver 2', 2)

--Hobro Vikings - Hold 2
insert into PlayerDB(teamID, clubID, IRLName, IGName, steamID, csgoRank, skillRating) values (2, 1, 'Arthur', 'Arthurius321', 'STEAM_0:0:11106', 'Silver 1', 1)
insert into PlayerDB(teamID, clubID, IRLName, IGName, steamID, csgoRank, skillRating) values (2, 1, 'Jeppe', 'TTV_Jeppi1G', 'STEAM_0:0:11107', 'Silver 1', 1)
insert into PlayerDB(teamID, clubID, IRLName, IGName, steamID, csgoRank, skillRating) values (2, 1, 'Frederik', 'Freder1kikuss', 'STEAM_0:0:11108', 'Silver 1', 1)
insert into PlayerDB(teamID, clubID, IRLName, IGName, steamID, csgoRank, skillRating) values (2, 1, 'Magnus', 'Magnum3D', 'STEAM_0:0:11109', 'Silver 1', 1)
insert into PlayerDB(teamID, clubID, IRLName, IGName, steamID, csgoRank, skillRating) values (2, 1, 'Mariane', 'iTzz_MarianneDobbeltRøv209_YT', 'STEAM_0:0:11110', 'Silver 1', 1)

--Dall Villaby - Hold 1
insert into PlayerDB(teamID, clubID, IRLName, IGName, steamID, csgoRank, skillRating) values (3, 2, 'Patrick', 'Archdragon', 'STEAM_0:0:11111', 'Unranked', 0)
insert into PlayerDB(teamID, clubID, IRLName, IGName, steamID, csgoRank, skillRating) values (3, 2, 'Ludwig', 'Ludderw1gz', 'STEAM_0:0:11112', 'Global Elite', 18)
insert into PlayerDB(teamID, clubID, IRLName, IGName, steamID, csgoRank, skillRating) values (3, 2, 'Peter', 'RaketUbådG8meren', 'STEAM_0:0:11113', 'Global Elite', 18)
insert into PlayerDB(teamID, clubID, IRLName, IGName, steamID, csgoRank, skillRating) values (3, 2, 'Simon', 'S1m0nTurboSl8eren', 'STEAM_0:0:11114', 'Global Elite', 18)
insert into PlayerDB(teamID, clubID, IRLName, IGName, steamID, csgoRank, skillRating) values (3, 2, 'Xander', 'XXXander', 'STEAM_0:0:11115', 'Global Elite', 18)

--Dall Villaby - Hold 2
insert into PlayerDB(teamID, clubID, IRLName, IGName, steamID, csgoRank, skillRating) values (4, 2, 'Luke', 'BubberDucky', 'STEAM_0:0:11116', 'Silver 1', 1)
insert into PlayerDB(teamID, clubID, IRLName, IGName, steamID, csgoRank, skillRating) values (4, 2, 'Max', 'ClankyHead', 'STEAM_0:0:11117', 'Silver 1', 1)
insert into PlayerDB(teamID, clubID, IRLName, IGName, steamID, csgoRank, skillRating) values (4, 2, 'Kira', 'kiraqt', 'STEAM_0:0:11118', 'Silver 1', 1)
insert into PlayerDB(teamID, clubID, IRLName, IGName, steamID, csgoRank, skillRating) values (4, 2, 'Christoffer', 'ElWacko', 'STEAM_0:0:11119', 'Silver 1', 1)
insert into PlayerDB(teamID, clubID, IRLName, IGName, steamID, csgoRank, skillRating) values (4, 2, 'Nicolai', 'Cidrew', 'STEAM_0:0:11120', 'Silver 1', 1)

--Creating League
insert into LeagueDB(leagueName, game, adminID, archiveFlag) values ('Nordjysk Liga - CS:GO', 'CS:GO', 'AdminID', 0)

--Creating Divisions
insert into DivisionsDB(divisionID, leagueID, divisionFormat, archiveFlag) values (1, 1, 'round-robin', 0)
insert into DivisionsDB(divisionID, leagueID, divisionFormat, archiveFlag) values (2, 1, 'round-robin', 0)

--Creating Matches
--Division 1 matches played
insert into MatchDB(divisionID, leagueID, team1ID, team2ID, team1Score, team2Score, startTime, playedFlag, hostClubID, serverIP) values (1, 1, 1, 3, 16, 10, 'Dette er Start time', 1, 1, 'Dette er server IP')
insert into MatchDB(divisionID, leagueID, team1ID, team2ID, team1Score, team2Score, startTime, playedFlag, hostClubID, serverIP) values (1, 1, 3, 1, 16, 10, 'Dette er Start time', 1, 3, 'Dette er server IP')
--Division 1 matches unplayed
insert into MatchDB(divisionID, leagueID, team1ID, team2ID, startTime, playedFlag, hostClubID, serverIP) values (1, 1, 3, 1, 'Dette er Start time', 0, 3, 'Dette er server IP')
insert into MatchDB(divisionID, leagueID, team1ID, team2ID, startTime, playedFlag, hostClubID, serverIP) values (1, 1, 1, 3, 'Dette er Start time', 0, 1, 'Dette er server IP')

--Division 2 matches played
insert into MatchDB(divisionID, leagueID, team1ID, team2ID, team1Score, team2Score, startTime, playedFlag, hostClubID, serverIP) values (2, 1, 2, 4, 16, 10, 'Dette er Start time', 1, 2, 'Dette er server IP')
insert into MatchDB(divisionID, leagueID, team1ID, team2ID, team1Score, team2Score, startTime, playedFlag, hostClubID, serverIP) values (2, 1, 4, 2, 16, 10, 'Dette er Start time', 1, 4, 'Dette er server IP')
--Division 2 matches unplayed
insert into MatchDB(divisionID, leagueID, team1ID, team2ID, startTime, playedFlag, hostClubID, serverIP) values (2, 1, 4, 2, 'Dette er Start time', 0, 4, 'Dette er server IP')
insert into MatchDB(divisionID, leagueID, team1ID, team2ID, startTime, playedFlag, hostClubID, serverIP) values (2, 1, 2, 4, 'Dette er Start time', 0, 2, 'Dette er server IP')
