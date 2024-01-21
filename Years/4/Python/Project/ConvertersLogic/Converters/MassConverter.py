from ConvertersLogic.Enums.Mass import Mass

class MassConverter:
    def convert(self, value, currentUnit, targetUnit):
        if currentUnit == targetUnit:
            return float(value)

        elif currentUnit == Mass.Tonnes and targetUnit == Mass.Kilogram:
            return float(value) * 1000.0
        elif currentUnit == Mass.Tonnes and targetUnit == Mass.Gram:
            return float(value) * float("1e+6")
        elif currentUnit == Mass.Tonnes and targetUnit == Mass.Milligram:
            return float(value) * float("1e+9")
        elif currentUnit == Mass.Tonnes and targetUnit == Mass.Microgram:
            return float(value) * float("1e+12")
        elif currentUnit == Mass.Tonnes and targetUnit == Mass.ImperialTon:
            return float(value) / 1.016
        elif currentUnit == Mass.Tonnes and targetUnit == Mass.UsTon:
            return float(value) * 1.102
        elif currentUnit == Mass.Tonnes and targetUnit == Mass.Stone:
            return float(value) * 157.0
        elif currentUnit == Mass.Tonnes and targetUnit == Mass.Pound:
            return float(value) * 2205.0
        elif currentUnit == Mass.Tonnes and targetUnit == Mass.Ounce:
            return float(value) * 35274.0

        elif currentUnit == Mass.Kilogram:
            return self.convertViaTonnes(value, currentUnit, targetUnit, float(value) / 1000.0)

        elif currentUnit == Mass.Gram:
            return self.convertViaTonnes(value, currentUnit, targetUnit, float(value) / float("1e+6"))

        elif currentUnit == Mass.Milligram:
            return self.convertViaTonnes(value, currentUnit, targetUnit, float(value) / float("1e+9"))

        elif currentUnit == Mass.Microgram:
            return self.convertViaTonnes(value, currentUnit, targetUnit, float(value) / float("1e+12"))

        elif currentUnit == Mass.ImperialTon:
            return self.convertViaTonnes(value, currentUnit, targetUnit, float(value) * 1.016)

        elif currentUnit == Mass.UsTon:
            return self.convertViaTonnes(value, currentUnit, targetUnit, float(value) / 1.102)

        elif currentUnit == Mass.Stone:
            return self.convertViaTonnes(value, currentUnit, targetUnit, float(value) / 157.0)

        elif currentUnit == Mass.Pound:
            return self.convertViaTonnes(value, currentUnit, targetUnit, float(value) / 2205.0)

        elif currentUnit == Mass.Ounce:
            return self.convertViaTonnes(value, currentUnit, targetUnit, float(value) / 35274.0)

        else:
            return float("nan")
    
    def convertViaTonnes(self, value, currentUnit, targetUnit, valueInTonnes):
        if currentUnit == targetUnit:
            return float(value)
        elif targetUnit == Mass.Tonnes:
            return float(valueInTonnes)
        else:
            return self.convert(self.convert(value, currentUnit, Mass.Tonnes), Mass.Tonnes, targetUnit)