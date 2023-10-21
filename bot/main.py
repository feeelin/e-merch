from aiogram import Bot, Dispatcher, executor, types

token = '6453622705:AAF9odlSTQFdBgkPXRTAwB_dZFJ-sCNU_qA'
bot = Bot(token)
dp = Dispatcher(bot)


@dp.message_handler(commands=['start'])
async def start_handler(message: types.Message):
    await message.answer('Откройте приложение по ссылке')


if __name__ == '__main__':
    executor.start_polling(dp)