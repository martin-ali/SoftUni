function solution(number)
{
    let sum = number;

    function add(number)
    {
        sum += number;

        return add;
    }

    add.toString = () => sum;

    return add;
}