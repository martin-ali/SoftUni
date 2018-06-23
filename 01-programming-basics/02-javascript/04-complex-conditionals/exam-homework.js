// jshint esversion:6
function hotelRoom([month, numberOfNights])
{
    month = month.toLowerCase();

    function getStudioDiscounts(month, numberOfNights)
    {
        month = month.toLowerCase();
        let discount = function()
        {
            let obj = {};
            obj.may = function(numberOfNights)
            {
                if (numberOfNights > 7 && numberOfNights <= 14)
                {
                    return 0.95;
                }
                else if (numberOfNights > 14)
                {
                    return 0.7;
                }
                else
                {
                    return 1;
                }
            };
            obj.october = obj.may;
            obj.june = function(numberOfNights)
            {
                if (numberOfNights > 14)
                {
                    return 0.8;
                }
                else
                {
                    return 1;
                }
            };
            obj.september = obj.june;

            return obj;
        }();

        let monthIsInDiscountPeriod = !!discount[month];
        if (monthIsInDiscountPeriod)
        {
            return discount[month](numberOfNights);
        }
        else
        {
            return 1;
        }
    }

    function getApartmentDiscounts(month, numberOfNights)
    {
        if (numberOfNights > 14)
        {
            return 0.9;
        }
        else
        {
            return 1;
        }
    }

    function getStudioPrice(month, numberOfNights)
    {
        month = month.toLowerCase();
        let pricing = function()
        {
            let obj = {};
            obj.may = 50;
            obj.june = 75.20;
            obj.july = 76;
            obj.august = obj.july;
            obj.september = obj.june;
            obj.october = obj.may;

            return obj;
        }();

        let test = pricing[month];
        return pricing[month] * numberOfNights;
    }

    function getApartmentPrice(month, numberOfNights)
    {
        month = month.toLowerCase();
        let pricing = function()
        {
            let obj = {};
            obj.may = 65;
            obj.june = 68.70;
            obj.july = 77;
            obj.august = obj.july;
            obj.september = obj.june;
            obj.october = obj.may;

            return obj;
        }();

        let test = pricing[month];
        return pricing[month] * numberOfNights;
    }

    let apartmentPricing = getApartmentPrice(month, numberOfNights);
    let apartmentDiscount = getApartmentDiscounts(month, numberOfNights);
    let apartmentFinalPrice = (apartmentPricing * apartmentDiscount).toFixed(2);

    let studioPricing = getStudioPrice(month, numberOfNights);
    let studioDiscount = getStudioDiscounts(month, numberOfNights);
    let studioFinalPrice = (studioPricing * studioDiscount).toFixed(2);

    console.log(`Apartment: ${apartmentFinalPrice} lv.`);
    console.log(`Studio: ${studioFinalPrice} lv.`);
}

// hotelRoom(['october', 17]);
// hotelRoom(['june', 14]);
