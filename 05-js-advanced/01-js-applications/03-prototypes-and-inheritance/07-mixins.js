function solve()
{
    function computerQualityMixin(classToExtend)
    {
        classToExtend.prototype.getQuality = function ()
        {
            const quality = (this.processorSpeed + this.ram + this.hardDiskSpace) / 3;

            return quality;
        }

        classToExtend.prototype.isFast = function ()
        {
            const isFast = this.processorSpeed > (this.ram / 4);

            return isFast;
        }

        classToExtend.prototype.isRoomy = function ()
        {
            const isRoomy = this.hardDiskSpace > Math.floor(this.ram * this.processorSpeed);

            return isRoomy;
        }
    }

    function styleMixin(classToExtend)
    {
        classToExtend.prototype.isFullSet = function ()
        {
            const isFullSet = this.manufacturer === this.keyboard.manufacturer
                && this.manufacturer === this.monitor.manufacturer;

            return isFullSet;
        }

        classToExtend.prototype.isClassy = function ()
        {
            const colorIsClassy = this.color === 'Silver' || this.color === 'Black';
            const isClassy = this.battery.expectedLife >= 3
                && colorIsClassy
                && this.weight < 3;

            return isClassy;
        }
    }

    return {
        computerQualityMixin,
        styleMixin
    }
}