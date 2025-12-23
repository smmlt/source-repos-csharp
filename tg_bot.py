from telegram import Update, InlineKeyboardButton, InlineKeyboardMarkup
from telegram.ext import ApplicationBuilder, CommandHandler, MessageHandler, CallbackQueryHandler, filters, ContextTypes

# Список доверенных username без @
trusted_users = {"smmlt"}

# Словарь для хранения количества голосов и ID сообщений
votes = {}

def is_trusted(user):
    return user.username in trusted_users if user and user.username else False

async def start(update: Update, context: ContextTypes.DEFAULT_TYPE):
    user = update.effective_user
    if is_trusted(user):
        await update.message.reply_text(
            f"Привет, {user.username or user.first_name}!\n"
            "Я музыкальный бот. Отправь мне mp3-файл, и я добавлю голосование к нему!"
        )
    else:
        await update.message.reply_text(
            f"Привет, {user.username or user.first_name}!\n"
            "Я музыкальный бот, но, к сожалению, у тебя нет доступа к его функциям.\n"
            "Если хочешь получить доступ — напиши [@smmlt](https://t.me/smmlt).",
            parse_mode="Markdown"
        )

# Обработка голосования
async def vote_callback(update: Update, context: ContextTypes.DEFAULT_TYPE):
    query = update.callback_query
    await query.answer()

    message_id = query.message.message_id
    data = query.data

    if message_id not in votes:
        votes[message_id] = {'heart': 0, 'fire': 0}
    
    if data == 'vote_heart':
        votes[message_id]['heart'] += 1
    elif data == 'vote_fire':
        votes[message_id]['fire'] += 1

    keyboard = [
        [
            InlineKeyboardButton(f"❤️ {votes[message_id]['heart']}", callback_data='vote_heart'),
            InlineKeyboardButton(f"🔥 {votes[message_id]['fire']}", callback_data='vote_fire'),
        ]
    ]
    await query.edit_message_reply_markup(reply_markup=InlineKeyboardMarkup(keyboard))

# Обработка аудиофайла
async def handle_audio(update: Update, context: ContextTypes.DEFAULT_TYPE):
    user = update.effective_user
    if not is_trusted(user):
        await update.message.reply_text(
            "У тебя нет доступа к использованию этого бота.\n"
            "Если хочешь получить доступ — напиши [@smmlt](https://t.me/smmlt).",
            parse_mode="Markdown"
        )
        return

    channel_id = "@vibehub_chanel"

    if update.message.audio or update.message.document:
        # Отправка пользователю
        msg = await update.message.reply_audio(
            audio=update.message.audio or update.message.document,
            caption="Проголосуй за трек!\n\n[VibeHub](https://t.me/vibehub_chanel)",
            parse_mode='Markdown',
            reply_markup=InlineKeyboardMarkup([
                [
                    InlineKeyboardButton("❤️ 0", callback_data='vote_heart'),
                    InlineKeyboardButton("🔥 0", callback_data='vote_fire'),
                ]
            ])
        )

        # Отправка в канал
        channel_msg = await context.bot.send_audio(
            chat_id=channel_id,
            audio=update.message.audio or update.message.document,
            caption="Проголосуй за трек!\n\n[VibeHub](https://t.me/vibehub_chanel)",
            parse_mode='Markdown',
            reply_markup=InlineKeyboardMarkup([
                [
                    InlineKeyboardButton("❤️ 0", callback_data='vote_heart'),
                    InlineKeyboardButton("🔥 0", callback_data='vote_fire'),
                ]
            ])
        )

        # Сохраняем информацию о голосах и ID сообщений в чате и канале
        votes[msg.message_id] = {'heart': 0, 'fire': 0, 'channel_msg_id': channel_msg.message_id}
        votes[channel_msg.message_id] = {'heart': 0, 'fire': 0, 'channel_msg_id': channel_msg.message_id}

# Функция для удаления трека
async def delete_audio(update: Update, context: ContextTypes.DEFAULT_TYPE):
    user = update.effective_user
    if not is_trusted(user):
        await update.message.reply_text(
            "У тебя нет доступа к удалению треков.\n"
            "Если хочешь получить доступ — напиши [@smmlt](https://t.me/smmlt).",
            parse_mode="Markdown"
        )
        return

    if update.message.reply_to_message and update.message.reply_to_message.audio:
        # Получаем ID сообщения с треком из личного чата
        track_message = update.message.reply_to_message

        # Удаляем сообщение в чате с пользователем
        await track_message.delete()
        await update.message.reply_text("Трек был удалён из чата.")

        # Также удаляем сообщение из канала
        try:
            channel_msg_id = votes.get(track_message.message_id, {}).get('channel_msg_id')
            if channel_msg_id:
                await context.bot.delete_message(chat_id="@vibehub_chanel", message_id=channel_msg_id)
                await update.message.reply_text("Трек был удалён и из канала.")
            else:
                await update.message.reply_text("Не удалось найти трек в канале.")
        except Exception as e:
            await update.message.reply_text(f"Не удалось удалить сообщение в канале: {e}")
    else:
        await update.message.reply_text("Пожалуйста, ответь на сообщение с треком для его удаления.")

# Запуск бота
def main():
    app = ApplicationBuilder().token("8094053897:AAEjy48PESdGgV6drvij2Ay-tCHqH4NATqk").build()

    app.add_handler(CommandHandler("start", start))
    app.add_handler(CommandHandler("delete", delete_audio))  # Добавляем обработчик для команды /delete
    app.add_handler(CallbackQueryHandler(vote_callback))
    app.add_handler(MessageHandler(filters.AUDIO | filters.Document.AUDIO, handle_audio))

    app.run_polling()

if __name__ == "__main__":
    main()


    #   8094053897:AAEjy48PESdGgV6drvij2Ay-tCHqH4NATqk