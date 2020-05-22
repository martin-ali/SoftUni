function solve(name, age, weightKg, heightCm)
{
    const heightM = heightCm / 100;
    const heightSquare = heightM ** 2;
    const bmi = weightKg / heightSquare;
    let status = 'underweight';
    let recommendation = null;

    if (bmi >= 30)
    {
        status = 'obese';
        recommendation = 'admission required';
    }
    else if (bmi >= 25)
    {
        status = 'overweight';
    }
    else if (bmi >= 18.5)
    {
        status = 'normal';
    }

    const bmiInfo = {
        name,
        personalInfo:
        {
            age,
            weight: weightKg,
            height: heightCm
        },
        BMI: Math.round(bmi),
        status
    };

    if (recommendation)
    {
        bmiInfo.recommendation = recommendation;
    }

    return bmiInfo;
}