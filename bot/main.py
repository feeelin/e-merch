from aiogram import Bot, Dispatcher, types, executor

token = '6453622705:AAF9odlSTQFdBgkPXRTAwB_dZFJ-sCNU_qA'
bot = Bot(token)
dp = Dispatcher(bot=bot)


@dp.message_handler(commands=['start'])
async def start_handler(message: types.Message):
    await message.answer('РАБОТАЕТ!')


if __name__ == '__main__':
    executor.start_polling(dp)
