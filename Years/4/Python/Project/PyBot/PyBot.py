import os, sys
sys.path.append(os.path.join(os.path.dirname(__file__), "..\\..\\Project"))

import telebot
from telebot.types import ReplyKeyboardMarkup, ReplyKeyboardRemove
from ConvertersLogic.Enums.Temperature import Temperature
from ConvertersLogic.Converters.TemperatureConverter import TemperatureConverter
from ConvertersLogic.Enums.Mass import Mass
from ConvertersLogic.Converters.MassConverter import MassConverter
from forex_python.converter import CurrencyRates
import simplejson as json

token = open("token.txt").read()
bot = telebot.TeleBot(token)

#TODO: keep dictionary(chat.id => selectedParameters) to provide separate settings per each chat.

currentConverter = TemperatureConverter()
currentTemperatureInputUnit = Temperature.Fahrenheit
currentTemperatureOutputUnit = Temperature.Celsius
currentMassInputUnit = Mass.Pound
currentMassOutputUnit = Mass.Kilogram
currentCurrencyInputUnit = "USD"
currentCurrencyOutputUnit = "EUR"
currencies = list(map(lambda x: x["cc"], json.loads(open("C:\\Users\\abuzhak\\AppData\\Local\\Programs\\Python\\Python38-32\\Lib\\site-packages\\forex_python\\raw_data\\currencies.json").read())))

str_SomethingWrong = "Something wrong."
str_InputUnitPrefix = "in_"
str_OutputUnitPrefix = "out_"
str_ChangingPrefix = "#"

str_Temperature = "Temperature"
str_Mass = "Mass"
str_Currency = "Currency"

def isNumber(s):
    try:
        float(s)
        return True
    except Exception:
        return False

def getConverterChangedString(converter):
    return "Converter changed to: " + converter

def getInputUnitChangedString(unit, converter):
    return "Input unit of " + converter + " converter changed to: " + unit

def getOutputUnitChangedString(unit, converter):
    return "Output unit of " + converter + " converter changed to: " + unit

def getKeyboardMarkup_Converters():
    markup = ReplyKeyboardMarkup()
    markup.row(str_ChangingPrefix + str_Temperature, str_ChangingPrefix + str_Mass, str_ChangingPrefix + str_Currency)
    return markup

def getKeyboardMarkup_TemperatureUnits(prefix):
    markup = ReplyKeyboardMarkup()
    markup.row(*list(map(lambda x: str_ChangingPrefix + prefix + str(x), Temperature().__dir__())))
    return markup

def getKeyboardMarkup_MassUnits(prefix):
    markup = ReplyKeyboardMarkup()
    markup.row_width = 3
    markup.add(*list(map(lambda x: str_ChangingPrefix + prefix + str(x), Mass().__dir__())))
    return markup

def getKeyboardMarkup_CurrencyUnits(prefix):
    markup = ReplyKeyboardMarkup()
    markup.row_width = 3
    markup.add(*list(map(lambda x: str_ChangingPrefix + prefix + str(x), currencies)))
    return markup

@bot.message_handler(commands=["converter"])
def selectConverterType(message):
    try:
        bot.send_message(message.chat.id, "Select converter type:", reply_markup=getKeyboardMarkup_Converters())
    except Exception as e:
        bot.send_message(message.chat.id, e, reply_markup=ReplyKeyboardRemove())

@bot.message_handler(commands=["input_unit"])
def selectInputUnit(message):
    try:
        markup = ReplyKeyboardRemove()

        if type(currentConverter) is TemperatureConverter:
            markup = getKeyboardMarkup_TemperatureUnits(str_InputUnitPrefix)
        elif type(currentConverter) is MassConverter:
            markup = getKeyboardMarkup_MassUnits(str_InputUnitPrefix)
        elif type(currentConverter) is CurrencyRates:
            markup = getKeyboardMarkup_CurrencyUnits(str_InputUnitPrefix)
        else:
            bot.send_message(message.chat.id, str_SomethingWrong, reply_markup=markup)

        bot.send_message(message.chat.id, "Select input unit:", reply_markup=markup)
    except Exception as e:
        bot.send_message(message.chat.id, e, reply_markup=ReplyKeyboardRemove())

@bot.message_handler(commands=["output_unit"])
def selectOutputUnit(message):
    try:
        markup = ReplyKeyboardRemove()

        if type(currentConverter) is TemperatureConverter:
            markup = getKeyboardMarkup_TemperatureUnits(str_OutputUnitPrefix)
        elif type(currentConverter) is MassConverter:
            markup = getKeyboardMarkup_MassUnits(str_OutputUnitPrefix)
        elif type(currentConverter) is CurrencyRates:
            markup = getKeyboardMarkup_CurrencyUnits(str_OutputUnitPrefix)
        else:
            bot.send_message(message.chat.id, str_SomethingWrong, reply_markup=markup)

        bot.send_message(message.chat.id, "Select input unit:", reply_markup=markup)
    except Exception as e:
        bot.send_message(message.chat.id, e, reply_markup=ReplyKeyboardRemove())

@bot.message_handler(content_types=["text"])
def sendAnswer(message):
    try:
        global currentConverter, currentTemperatureInputUnit, currentTemperatureOutputUnit, currentMassInputUnit, currentMassOutputUnit, currentCurrencyInputUnit, currentCurrencyOutputUnit
        converter = ""
        inputUnit = ""
        outputUnit = ""
        outputValue = ""
        m = message.text
        is_number = isNumber(m)

        if is_number:
            if type(currentConverter) is TemperatureConverter:
                outputValue = currentConverter.convert(float(m), currentTemperatureInputUnit, currentTemperatureOutputUnit)
                converter = str_Temperature
                inputUnit = str(currentTemperatureInputUnit)
                outputUnit = str(currentTemperatureOutputUnit)
            elif type(currentConverter) is MassConverter:
                outputValue = currentConverter.convert(float(m), currentMassInputUnit, currentMassOutputUnit)
                converter = str_Mass
                inputUnit = str(currentMassInputUnit)
                outputUnit = str(currentMassOutputUnit)
            elif type(currentConverter) is CurrencyRates:
                outputValue = currentConverter.convert(currentCurrencyInputUnit, currentCurrencyOutputUnit, float(m))
                converter = str_Currency
                inputUnit = str(currentCurrencyInputUnit)
                outputUnit = str(currentCurrencyOutputUnit)
            else:
                bot.send_message(message.chat.id, str_SomethingWrong, reply_markup=ReplyKeyboardRemove())
                return

            bot.send_message(message.chat.id, "Converter: " + converter + "\n" + "Input unit: " + inputUnit + "\n" + "Output unit: " + outputUnit + "\n" + "Input value: " + str(float(m)) + "\n" + "Output value: " + str(round(outputValue, 3)), reply_markup=ReplyKeyboardRemove())
        elif len(m) >= len(str_ChangingPrefix) and m.startswith(str_ChangingPrefix):
            what_changed_str = ""
            m = m[len(str_ChangingPrefix):len(m)]

            if m == str_Temperature:
                currentConverter = TemperatureConverter()
                what_changed_str = getConverterChangedString(str_Temperature)
            elif m == str_Mass:
                currentConverter = MassConverter()
                what_changed_str = getConverterChangedString(str_Mass)
            elif m == str_Currency:
                currentConverter = CurrencyRates()
                what_changed_str = getConverterChangedString(str_Currency)

            elif m.startswith(str_InputUnitPrefix):
                _inUnit = m[len(str_InputUnitPrefix):len(m)]

                if hasattr(Temperature, _inUnit):
                    currentTemperatureInputUnit = _inUnit
                    what_changed_str = getInputUnitChangedString(_inUnit, str_Temperature)
                elif hasattr(Mass, _inUnit):
                    currentMassInputUnit = _inUnit
                    what_changed_str = getInputUnitChangedString(_inUnit, str_Mass)
                elif _inUnit in currencies:
                    currentCurrencyInputUnit = _inUnit
                    what_changed_str = getInputUnitChangedString(_inUnit, str_Currency)
                else:
                    return

            elif m.startswith(str_OutputUnitPrefix):
                _outUnit = m[len(str_OutputUnitPrefix):len(m)]

                if hasattr(Temperature, _outUnit):
                    currentTemperatureOutputUnit = _outUnit
                    what_changed_str = getOutputUnitChangedString(_outUnit, str_Temperature)
                elif hasattr(Mass, _outUnit):
                    currentMassOutputUnit = _outUnit
                    what_changed_str = getOutputUnitChangedString(_outUnit, str_Mass)
                elif _outUnit in currencies:
                    currentCurrencyOutputUnit = _outUnit
                    what_changed_str = getOutputUnitChangedString(_outUnit, str_Currency)
                else:
                    return
            
            else:
                return

            bot.send_message(message.chat.id, what_changed_str, reply_markup=ReplyKeyboardRemove())
    except Exception as e:
        bot.send_message(message.chat.id, e, reply_markup=ReplyKeyboardRemove())

bot.polling(none_stop=True)