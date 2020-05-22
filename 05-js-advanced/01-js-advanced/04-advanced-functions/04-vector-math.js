(function ()
{
    const vectorMath = {
        add: ([xA, yA], [xB, yB]) => [xA + xB, yA + yB],

        multiply: ([xA, yA], scalar) => [xA * scalar, yA * scalar],

        length: ([x, y]) => Math.sqrt(x ** 2 + y ** 2),

        dot: ([xA, yA], [xB, yB]) => xA * xB + yA * yB,

        cross: ([xA, yA], [xB, yB]) => xA * yB - yA * xB
    };

    return vectorMath;
})();