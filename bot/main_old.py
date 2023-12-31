import telebot
from telebot import types

bot = telebot.TeleBot("6451239638:AAH-DINV9PDFiNyT0yv2HbESJoYHTrDT2nU")


@bot.message_handler(commands=['start'])
def start(message):
    markup = types.ReplyKeyboardMarkup(resize_keyboard=True)
    btn1 = types.KeyboardButton("Список товаров")
    btn2 = types.KeyboardButton("Баланс")
    btn3 = types.KeyboardButton("История покупок")
    markup.add(btn1, btn2, btn3)
    bot.send_message(message.chat.id,
                     text="Привет, {0.first_name}! Я бот для покупок во внутреннем магазине INTENSA".format(
                         message.from_user), reply_markup=markup)


@bot.message_handler(content_types=['text'])
def func(message):
    if message.text == "Список товаров":
            markup = types.InlineKeyboardMarkup()
            button1 = types.InlineKeyboardButton(text='Толстовка', callback_data='толстовка')
            button2 = types.InlineKeyboardButton(text='Кепка', callback_data='кепка')
            button3 = types.InlineKeyboardButton(text='Футболка', callback_data='футболка')
            button4 = types.InlineKeyboardButton(text='Блокнот', callback_data="блокнот")
            markup.add(button1, button2, button3, button4)
            bot.send_message(message.chat.id,
                             "Выбери свой товар:".format(message.from_user),
                             reply_markup=markup)
            bot.polling(none_stop=True)

    elif message.text == "Баланс":
        bot.send_message(message.chat.id, "10000000000000")
    elif message.text == "История покупок":
        bot.send_message(message.chat.id, "ты купил 100 толстовок")
    else:
        bot.send_message(message.chat.id, text="...")


@bot.callback_query_handler(func=lambda call: True)
def callback_inline(call):
    if call.message:
        if call.data == "толстовка":
            bot.edit_message_text(chat_id=call.message.chat.id, message_id=call.message.message_id, text="Самая лучшая толстовка")
        elif call.data == "кепка":
            bot.edit_message_text(chat_id=call.message.chat.id, message_id=call.message.message_id, text="Одна из самый крутых кепок на планете")
        elif call.data == "футболка":
            bot.edit_message_text(chat_id=call.message.chat.id, message_id=call.message.message_id, text="Лучший выбор для свидания")
        elif call.data == "блокнот":
            bot.edit_message_text(chat_id=call.message.chat.id, message_id=call.message.message_id, text="Наилучшее место для ваших мыслей")


bot.polling(none_stop=True)
