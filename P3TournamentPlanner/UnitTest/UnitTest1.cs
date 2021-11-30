using NUnit.Framework;
using P3TournamentPlanner.Server.Controllers;
using P3TournamentPlanner.Shared;
using System.Collections.Generic;

namespace UnitTest {
    public class Tests {

        private static readonly object[] genMatchSource = {
            new object[] {
                1,
                true,
                new List<Division> {
                    new Division {
                        divisionID = 1,
                        teams = new List<Team> {
                            new Team {
                                teamID = 1,
                                clubID = 1,
                                divisionID = 1,
                                leagueID = 1,
                                teamName = "Team1",
                                teamSkillRating = 420,
                                manager = new ClubManager() {
                                    contactinfo = new Contactinfo() {
                                        userID = "Team1ManID",
                                        name = "Team1ManName",
                                        tlfNr = "Team1ManTlf",
                                        discordID = "Team1ManDisc",
                                        email = "Team1ManMail"
                                    }
                                }
                            },
                            new Team {
                                teamID = 2,
                                clubID = 2,
                                divisionID = 1,
                                leagueID = 1,
                                teamName = "Team2",
                                teamSkillRating = 410,
                                manager = new ClubManager() {
                                    contactinfo = new Contactinfo() {
                                        userID = "Team2ManID",
                                        name = "Team2ManName",
                                        tlfNr = "Team2ManTlf",
                                        discordID = "Team2ManDisc",
                                        email = "Team2ManMail"
                                    }
                                }
                            },
                            new Team {
                                teamID = 3,
                                clubID = 1,
                                divisionID = 1,
                                leagueID = 1,
                                teamName = "Team3",
                                teamSkillRating = 405,
                                manager = new ClubManager() {
                                    contactinfo = new Contactinfo() {
                                        userID = "Team3ManID",
                                        name = "Team3ManName",
                                        tlfNr = "Team3ManTlf",
                                        discordID = "Team3ManDisc",
                                        email = "Team3ManMail"
                                    }
                                }
                            }
                        },
                        matches = new List<Match>{}
                        //new Team(1, 1, 1, 1, "Team1", 420, new ClubManager(new Contactinfo("Team1ManID", "Team1ManName", "Team1ManTlf", "Team1ManDisc", "Team1ManMail"))),
                        //new Team(2, 2, 1, 1, "Team2", 410, new ClubManager(new Contactinfo("Team2ManID", "Team2ManName", "Team2ManTlf", "Team2ManDisc", "Team2ManMail"))),
                        //new Team(3, 1, 1, 1, "Team3", 405, new ClubManager(new Contactinfo("Team3ManID", "Team3ManName", "Team3ManTlf", "Team3ManDisc", "Team3ManMail")))

                        },
                    new Division {
                        divisionID = 2,
                        teams = new List<Team> {
                            new Team {
                                teamID = 4,
                                clubID = 1,
                                divisionID = 2,
                                leagueID = 1,
                                teamName = "Team4",
                                teamSkillRating = 400,
                                manager = new ClubManager() {
                                    contactinfo = new Contactinfo() {
                                        userID = "Team4ManID",
                                        name = "Team4ManName",
                                        tlfNr = "Team4ManTlf",
                                        discordID = "Team4ManDisc",
                                        email = "Team4ManMail"
                                    }
                                }
                            },
                            new Team {
                                teamID = 5,
                                clubID = 2,
                                divisionID = 2,
                                leagueID = 1,
                                teamName = "Team5",
                                teamSkillRating = 390,
                                manager = new ClubManager() {
                                    contactinfo = new Contactinfo() {
                                        userID = "Team5ManID",
                                        name = "Team5ManName",
                                        tlfNr = "Team5ManTlf",
                                        discordID = "Team5ManDisc",
                                        email = "Team5ManMail"
                                    }
                                }
                            }
                        },
                        matches = new List<Match>{}
                        //new Team(4, 1, 2, 1, "Team4", 400, new ClubManager(new Contactinfo("Team4ManID", "Team4ManName", "Team4ManTlf", "Team4ManDisc", "Team4ManMail"))),
                        //new Team(5, 2, 2, 1, "Team5", 390, new ClubManager(new Contactinfo("Team5ManID", "Team5ManName", "Team5ManTlf", "Team5ManDisc", "Team5ManMail")))

                    }
                },
                new List<int> {
                    3,
                    1
                }
            }
        };

        //[TestCase(1, true, testDivList)]
        [TestCaseSource("genMatchSource")]
        public void GenMatchTest(int leagueID, bool testing, List<Division> testDivList, List<int> expectedMatchAmount) {
            var sut = new AdminController();
            int count = 0;
            testDivList = sut.GenerateMatches(leagueID, testing, testDivList);
            foreach(Division div in testDivList) {
                Assert.That(div.matches.Count, Is.EqualTo(expectedMatchAmount[count]));
                count++;
            }
        }
    }
}