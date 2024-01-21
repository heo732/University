from ConvertersLogic.Enums.Temperature import Temperature

class TemperatureConverter:
    def convert(self, value, currentUnit, targetUnit):
        if currentUnit == targetUnit:
            return float(value)

        elif currentUnit == Temperature.Celsius and targetUnit == Temperature.Kelvin:
            return float(value) + 273.15
        elif currentUnit == Temperature.Celsius and targetUnit == Temperature.Fahrenheit:
            return (float(value) * (9.0 / 5.0)) + 32.0

        elif currentUnit == Temperature.Kelvin:
            return self.convertViaCelsius(value, currentUnit, targetUnit, float(value) - 273.15)

        elif currentUnit == Temperature.Fahrenheit:
            return self.convertViaCelsius(value, currentUnit, targetUnit, (float(value) - 32.0) * (5.0 / 9.0))

        else:
            return float("nan")

    def convertViaCelsius(self, value, currentUnit, targetUnit, valueInCelsius):
        if currentUnit == targetUnit:
            return float(value)
        elif targetUnit == Temperature.Celsius:
            return float(valueInCelsius)
        else:
            return self.convert(self.convert(value, currentUnit, Temperature.Celsius), Temperature.Celsius, targetUnit)