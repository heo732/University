class Temperature:
    Celsius = "Celsius"
    Fahrenheit = "Fahrenheit"
    Kelvin = "Kelvin"

    def __dir__(self):
        return [Temperature.Celsius, Temperature.Fahrenheit, Temperature.Kelvin]