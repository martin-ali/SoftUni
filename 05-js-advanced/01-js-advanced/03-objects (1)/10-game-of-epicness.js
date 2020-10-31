function solve(kingdomsInfo, battles)
{
    function generateIdByKingdomAndGeneral(kingdom, general)
    {
        return `${kingdom} | ${general}`;
    }

    const generalsByKingdom = new Map();
    const armyById = new Map();
    const winsById = new Map();
    const lossesById = new Map();
    const winsByKingdom = {};
    const lossesByKingdom = {};

    for (const { kingdom, general, army } of kingdomsInfo)
    {
        const newArmy = parseInt(army);
        const kingdomGeneral = generateIdByKingdomAndGeneral(kingdom, general);

        if (winsByKingdom.hasOwnProperty(kingdom) === false)
        {
            winsByKingdom[kingdom] = 0;
        }

        if (lossesByKingdom.hasOwnProperty(kingdom) === false)
        {
            lossesByKingdom[kingdom] = 0;
        }

        if (generalsByKingdom.has(kingdom) === false)
        {
            generalsByKingdom.set(kingdom, new Set());
        }

        generalsByKingdom
            .get(kingdom)
            .add(general);

        if (armyById.has(kingdomGeneral) === false)
        {
            armyById.set(kingdomGeneral, 0);
        }

        const oldArmy = armyById.get(kingdomGeneral);
        const totalArmy = newArmy + oldArmy;

        armyById.set(kingdomGeneral, totalArmy);
    }

    for (const [attackingKingdom, attackingGeneral, defendingKingdom, defendingGeneral] of battles)
    {
        const attackerId = generateIdByKingdomAndGeneral(attackingKingdom, attackingGeneral);
        const attackerArmy = armyById.get(attackerId);

        const defenderId = generateIdByKingdomAndGeneral(defendingKingdom, defendingGeneral);
        const defenderArmy = armyById.get(defenderId);

        if (attackingKingdom === defendingKingdom || attackerArmy === defenderArmy)
        {
            continue;
        }

        let winner = {
            id: attackerId,
            army: attackerArmy,
            kingdom: attackingKingdom
        };
        let loser = {
            id: defenderId,
            army: defenderArmy,
            kingdom: defendingKingdom
        };

        if (defenderArmy > attackerArmy)
        {
			[winner, loser] = [loser, winner];
        }

        const newWinnerArmy = Math.floor(winner.army * 1.10);
        armyById.set(winner.id, newWinnerArmy);

        const newLoserArmy = Math.floor(loser.army * 0.90);
        armyById.set(loser.id, newLoserArmy);

        if (winsById.has(winner.id) === false)
        {
            winsById.set(winner.id, 0);
        }

        const winnerOldWinsCount = winsById.get(winner.id);
        winsById.set(winner.id, winnerOldWinsCount + 1);
        winsByKingdom[winner.kingdom] += 1;

        if (lossesById.has(loser.id) === false)
        {
            lossesById.set(loser.id, 0);
        }

        const loserOldLossesCount = lossesById.get(loser.id);
        lossesById.set(loser.id, loserOldLossesCount + 1);
        lossesByKingdom[loser.kingdom] += 1;
    }

    const sortedKingdoms = Array.from(generalsByKingdom);
    sortedKingdoms.sort(([kingdomA, generalsA], [kingdomB, generalsB]) =>
    {
        if (winsByKingdom[kingdomA] !== winsByKingdom[kingdomB])
        {
            return winsByKingdom[kingdomB] - winsByKingdom[kingdomA];
        }
        else if (lossesByKingdom[kingdomA] !== lossesByKingdom[kingdomB])
        {
            return lossesByKingdom[kingdomA] - lossesByKingdom[kingdomB];
        }
        else
        {
            return kingdomA.localeCompare(kingdomB);
        }
    });

    const [winnerKingdom, winnerGenerals] = sortedKingdoms[0];
    console.log(`Winner: ${winnerKingdom}`);

    const orderedWinnerGenerals = Array
        .from(winnerGenerals)
        .sort((generalA, generalB) =>
        {
            const idA = generateIdByKingdomAndGeneral(winnerKingdom, generalA);
            const idB = generateIdByKingdomAndGeneral(winnerKingdom, generalB);

            return armyById.get(idB) - armyById.get(idA);
        });

    for (const general of orderedWinnerGenerals)
    {
        const id = generateIdByKingdomAndGeneral(winnerKingdom, general);
        const army = armyById.get(id);
        const wins = winsById.get(id) || 0;
        const losses = lossesById.get(id) || 0;

        console.log(`/\\general: ${general}`)
        console.log(`---army: ${army}`);
        console.log(`---wins: ${wins}`);
        console.log(`---losses: ${losses}`);
    }
}

// solve([
//         {
//             kingdom: "Maiden Way",
//             general: "Merek",
//             army: 5000
// },

//         {
//             kingdom: "Stonegate",
//             general: "Ulric",
//             army: 4900
// },

//         {
//             kingdom: "Stonegate",
//             general: "Doran",
//             army: 70000
// },

//         {
//             kingdom: "YorkenShire",
//             general: "Quinn",
//             army: 0
// },

//         {
//             kingdom: "YorkenShire",
//             general: "Quinn",
//             army: 2000
// },

//         {
//             kingdom: "Maiden Way",
//             general: "Berinon",
//             army: 100000
// }
// ],
// [
//     ["YorkenShire", "Quinn", "Stonegate", "Ulric"],
//     ["Stonegate", "Ulric", "Stonegate", "Doran"],
//     ["Stonegate", "Doran", "Maiden Way", "Merek"],
//     ["Stonegate", "Ulric", "Maiden Way", "Merek"],
//     ["Maiden Way", "Berinon", "Stonegate", "Ulric"]
// ]);

// solve([
//         {
//             kingdom: "Stonegate ",
//             general: "Ulric ",
//             army: 5000
// },
//         {
//             kingdom: "YorkenShire ",
//             general: "Quinn ",
//             army: 5000
// },
//         {
//             kingdom: "Maiden Way ",
//             general: "Berinon ",
//             army: 1000
// }],
// [
// 	["YorkenShire ", "Quinn ", "Stonegate ", "Ulric "],
// 	["Maiden Way ", "Berinon ", "YorkenShire ", "Quinn "]
// ]);

// solve([
//         {
//             kingdom: "Maiden Way ",
//             general: "Merek ",
//             army: 5000
// },
//         {
//             kingdom: "Stonegate ",
//             general: "Ulric ",
//             army: 4900
// },
//         {
//             kingdom: "Stonegate ",
//             general: "Doran ",
//             army: 70000
// },
//         {
//             kingdom: "YorkenShire ",
//             general: "Quinn ",
//             army: 0
// },
//         {
//             kingdom: "YorkenShire ",
//             general: "Quinn ",
//             army: 2000
// }
// ],
// [
// 	["YorkenShire ", "Quinn ", "Stonegate ", "Doran "],
// 	["Stonegate ", "Ulric ", "Maiden Way ", "Merek "]
// ]);