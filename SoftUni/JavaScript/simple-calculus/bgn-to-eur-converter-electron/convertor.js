function eurConvertor()
{
    let bgn = +document.getElementById('bgn').value;
    let eur = (bgn / 1.95583).toFixed(2);

    document.getElementById('eur').value = eur;
}