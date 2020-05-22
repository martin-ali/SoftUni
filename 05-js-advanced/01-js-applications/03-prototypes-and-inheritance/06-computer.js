function solve()
{
    class Device
    {
        manufacturer;

        constructor(manufacturer)
        {
            this.manufacturer = manufacturer;
        }
    }

    class Keyboard extends Device
    {
        responseTime;

        constructor(manufacturer, responseTime)
        {
            super(manufacturer);

            this.responseTime = responseTime;
        }
    }

    class Monitor extends Device
    {
        width;
        height;

        constructor(manufacturer, width, height)
        {
            super(manufacturer);

            this.width = width;
            this.height = height;
        }
    }

    class Battery extends Device
    {
        expectedLife;

        constructor(manufacturer, expectedLife)
        {
            super(manufacturer);

            this.expectedLife = expectedLife;
        }
    }

    class Computer extends Device
    {
        processorSpeed;
        ram;
        hardDiskSpace

        constructor(manufacturer, processorSpeed, ram, hardDiskSpace)
        {
            if (new.target === Computer)
            {
                throw new Error();
            }

            super(manufacturer);

            this.processorSpeed = processorSpeed;
            this.ram = ram;
            this.hardDiskSpace = hardDiskSpace;
        }
    }

    class Laptop extends Computer
    {
        _battery;

        weight;
        color;

        constructor(manufacturer, processorSpeed, ram, hardDiskSpace, weight, color, battery)
        {
            super(manufacturer, processorSpeed, ram, hardDiskSpace);

            this.weight = weight;
            this.color = color;
            this.battery = battery;
        }

        get battery()
        {
            return this._battery;
        }

        set battery(value)
        {
            const valueIsBattery = value instanceof Battery;

            if (!valueIsBattery)
            {
                throw new TypeError();
            }

            this._battery = value;
        }
    }

    class Desktop extends Computer
    {
        _keyboard;
        _monitor;

        constructor(manufacturer, processorSpeed, ram, hardDiskSpace, keyboard, monitor)
        {
            super(manufacturer, processorSpeed, ram, hardDiskSpace);

            this.keyboard = keyboard;
            this.monitor = monitor;
        }

        get keyboard()
        {
            return this._keyboard;
        }

        set keyboard(value)
        {
            const valueIsKeyboard = value instanceof Keyboard;

            if (!valueIsKeyboard)
            {
                throw new TypeError();
            }

            this._keyboard = value;
        }

        get monitor()
        {
            return this._monitor;
        }

        set monitor(value)
        {
            const valueIsMonitor = value instanceof Monitor;

            if (!valueIsMonitor)
            {
                throw new TypeError();
            }

            this._monitor = value;
        }
    }

    return {
        Battery,
        Keyboard,
        Monitor,
        Computer,
        Laptop,
        Desktop
    }
}