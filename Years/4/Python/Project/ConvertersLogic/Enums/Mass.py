class Mass:
    Tonnes = "Tonnes"
    Kilogram = "Kilogram"
    Gram = "Gram"
    Milligram = "Milligram"
    Microgram = "Microgram"
    ImperialTon = "ImperialTon"
    UsTon = "UsTon"
    Stone = "Stone"
    Pound = "Pound"
    Ounce = "Ounce"

    def __dir__(self):
        return [Mass.Tonnes, Mass.Kilogram, Mass.Gram, Mass.Milligram, Mass.Microgram, Mass.ImperialTon, Mass.UsTon, Mass.Stone, Mass.Pound, Mass.Ounce]