from aiogram import Bot, Dispatcher, executor, types

token = '6453622705:AAF9odlSTQFdBgkPXRTAwB_dZFJ-sCNU_qA'
bot = Bot(token)
dp = Dispatcher(bot)


@dp.message_handler(commands=['start'])
async def start_handler(message: types.Message):
    keyboard = types.InlineKeyboardMarkup()
    web_app_button = types.KeyboardButton(text='Открыть приложение', web_app=types.WebAppInfo(url='https://emerch.nakodeelee.ru/'))
    keyboard.add(web_app_button)

    await message.answer('Наш бот ещё не до конца проснулся 😞\n\n'
                         'Мы обязательно его разбудим, а пока можно воспользоваться веб-приложением по ссылке',
                         reply_markup=keyboard)


if __name__ == '__main__':
    executor.start_polling(dp)