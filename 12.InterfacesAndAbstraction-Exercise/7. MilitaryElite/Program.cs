using MilitaryElite.Interfaces;
using MilitaryElite.Models;

List<ISoldier> soldiers = new List<ISoldier>();
List<Private> privates = new();
string input = string.Empty;

while ((input = Console.ReadLine()) != "End")
{
    string[] info = input
        .Split(" ", StringSplitOptions.RemoveEmptyEntries);
    string type = info[0];
    switch (type)
    {
        case "Private":
            Private currentPrivate = new(info[1], info[2], info[3], decimal.Parse(info[4]));
            privates.Add(currentPrivate);
            soldiers.Add(currentPrivate);
            break;
        case "LieutenantGeneral":
            string[] privatesIdsUnderGeneral = info.Skip(5).ToArray();
            List<Private> privatesUnderGeneral = new();
            for (int i = 0; i < privatesIdsUnderGeneral.Length; i++)
            {
                if (privates.Any(x => x.Id == privatesIdsUnderGeneral[i]))
                {
                    privatesUnderGeneral.Add(privates.FirstOrDefault(y => y.Id == privatesIdsUnderGeneral[i]));
                }
            }
            LieutenantGeneral lieutenantGeneral = new(info[1], info[2], info[3], decimal.Parse(info[4]), privatesUnderGeneral);
            soldiers.Add(lieutenantGeneral);
            break;
        case "Engineer":
            if (info[5] != "Airforces" && info[5] != "Marines")
            {
                continue;
            }
            string[] repairsInfo = info.Skip(6).ToArray();
            List<Repair> repairs = new();
            for (int i = 0; i < repairsInfo.Length; i += 2)
            {
                Repair currentRepair = new(repairsInfo[i], int.Parse(repairsInfo[i + 1]));
                repairs.Add(currentRepair);
            }
            Engineer engineer = new(info[1], info[2], info[3], decimal.Parse(info[4]), info[5], repairs);
            soldiers.Add(engineer);
            break;
        case "Commando":
            if (info[5] != "Airforces" && info[5] != "Marines")
            {
                continue;
            }
            string[] missionsInfo = info.Skip(6).ToArray();
            List<Mission> missions = new();
            for (int i = 0; i < missionsInfo.Length; i += 2)
            {
                if (missionsInfo[i + 1] != "inProgress" && missionsInfo[i + 1] != "Finished")
                {
                    continue;
                }
                Mission currentMission = new(missionsInfo[i], missionsInfo[i + 1]);
                missions.Add(currentMission);
            }
            Commando commando = new(info[1], info[2], info[3], decimal.Parse(info[4]), info[5], missions);
            soldiers.Add(commando);
            break;
        case "Spy":
            Spy spy = new(info[1], info[2], info[3], int.Parse(info[4]));
            soldiers.Add(spy);
            break;
    }
}

foreach (var soldier in soldiers)
{
    Console.WriteLine(soldier);
}
