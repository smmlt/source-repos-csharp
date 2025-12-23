# from telegram import Update, InlineKeyboardButton, InlineKeyboardMarkup
# from telegram.ext import ApplicationBuilder, CommandHandler, MessageHandler, CallbackQueryHandler, filters, ContextTypes

# # Список доверенных username без @
# trusted_users = {"smmlt"}

# # Словарь для хранения количества голосов и ID сообщений
# votes = {}

# def is_trusted(user):
#     return user.username in trusted_users if user and user.username else False

# async def start(update: Update, context: ContextTypes.DEFAULT_TYPE):
#     user = update.effective_user
#     if is_trusted(user):
#         await update.message.reply_text(
#             f"Привет, {user.username or user.first_name}!\n"
#             "Я музыкальный бот. Отправь мне mp3-файл, и я добавлю голосование к нему!"
#         )
#     else:
#         await update.message.reply_text(
#             f"Привет, {user.username or user.first_name}!\n"
#             "Я музыкальный бот, но, к сожалению, у тебя нет доступа к его функциям.\n"
#             "Если хочешь получить доступ — напиши [@smmlt](https://t.me/smmlt).",
#             parse_mode="Markdown"
#         )

# # Обработка голосования
# async def vote_callback(update: Update, context: ContextTypes.DEFAULT_TYPE):
#     query = update.callback_query
#     user = update.effective_user
#     message_id = query.message.message_id
#     data = query.data

#     # Инициализация голосов, если нужно
#     if message_id not in votes:
#         votes[message_id] = {'heart': 0, 'fire': 0, 'voted_users': set()}

#     # Проверка, голосовал ли уже
#     if not is_trusted(user) and user.id in votes[message_id].get('voted_users', set()):
#         await query.answer("Вы уже голосовали за этот трек!", show_alert=True)
#         return

#     # Благодарим заранее, до обновления сообщений
#     if is_trusted(user):
#         await query.answer("Голос учтён.")
#     else:
#         await query.answer("Спасибо, ваше мнение очень важно!")

#     # Обработка голоса
#     if data == 'vote_heart':
#         votes[message_id]['heart'] += 1
#     elif data == 'vote_fire':
#         votes[message_id]['fire'] += 1

#     # Запоминаем голос
#     if not is_trusted(user):
#         votes[message_id]['voted_users'].add(user.id)

#     # Обновление кнопок
#     keyboard = [
#         [
#             InlineKeyboardButton(f"❤️ {votes[message_id]['heart']}", callback_data='vote_heart'),
#             InlineKeyboardButton(f"🔥 {votes[message_id]['fire']}", callback_data='vote_fire'),
#         ]
#     ]

#     try:
#         await query.edit_message_reply_markup(reply_markup=InlineKeyboardMarkup(keyboard))
#     except Exception as e:
#         print(f"Ошибка обновления кнопок: {e}")

# # Обработка аудиофайла
# async def handle_audio(update: Update, context: ContextTypes.DEFAULT_TYPE):
#     user = update.effective_user
#     if not is_trusted(user):
#         await update.message.reply_text(
#             "У тебя нет доступа к использованию этого бота.\n"
#             "Если хочешь получить доступ — напиши [@smmlt](https://t.me/smmlt).",
#             parse_mode="Markdown"
#         )
#         return

#     channel_id = "@vibehub_chanel"

#     if update.message.audio or update.message.document:
#         # Отправка пользователю
#         msg = await update.message.reply_audio(
#             audio=update.message.audio or update.message.document,
#             caption="Проголосуй за трек!\n\n[VibeHub](https://t.me/vibehub_chanel)",
#             parse_mode='Markdown',
#             reply_markup=InlineKeyboardMarkup([
#                 [
#                     InlineKeyboardButton("❤️ 0", callback_data='vote_heart'),
#                     InlineKeyboardButton("🔥 0", callback_data='vote_fire'),
#                 ]
#             ])
#         )

#         # Отправка в канал
#         channel_msg = await context.bot.send_audio(
#             chat_id=channel_id,
#             audio=update.message.audio or update.message.document,
#             caption="Проголосуй за трек!\n\n[VibeHub](https://t.me/vibehub_chanel)",
#             parse_mode='Markdown',
#             reply_markup=InlineKeyboardMarkup([
#                 [
#                     InlineKeyboardButton("❤️ 0", callback_data='vote_heart'),
#                     InlineKeyboardButton("🔥 0", callback_data='vote_fire'),
#                 ]
#             ])
#         )

#         # Сохраняем информацию о голосах и ID сообщений в чате и канале
#         votes[msg.message_id] = {'heart': 0, 'fire': 0, 'channel_msg_id': channel_msg.message_id}
#         votes[channel_msg.message_id] = {'heart': 0, 'fire': 0, 'channel_msg_id': channel_msg.message_id}

# # Функция для удаления трека
# async def delete_audio(update: Update, context: ContextTypes.DEFAULT_TYPE):
#     user = update.effective_user
#     if not is_trusted(user):
#         await update.message.reply_text(
#             "У тебя нет доступа к удалению треков.\n"
#             "Если хочешь получить доступ — напиши [@smmlt](https://t.me/smmlt).",
#             parse_mode="Markdown"
#         )
#         return

#     if update.message.reply_to_message and update.message.reply_to_message.audio:
#         # Получаем ID сообщения с треком из личного чата
#         track_message = update.message.reply_to_message

#         # Удаляем сообщение в чате с пользователем
#         await track_message.delete()
#         await update.message.reply_text("Трек был удалён из чата.")

#         # Также удаляем сообщение из канала
#         try:
#             channel_msg_id = votes.get(track_message.message_id, {}).get('channel_msg_id')
#             if channel_msg_id:
#                 await context.bot.delete_message(chat_id="@vibehub_chanel", message_id=channel_msg_id)
#                 await update.message.reply_text("Трек был удалён и из канала.")
#             else:
#                 await update.message.reply_text("Не удалось найти трек в канале.")
#         except Exception as e:
#             await update.message.reply_text(f"Не удалось удалить сообщение в канале: {e}")
#     else:
#         await update.message.reply_text("Пожалуйста, ответь на сообщение с треком для его удаления.")

# # Запуск бота
# def main():
#     app = ApplicationBuilder().token("8094053897:AAEjy48PESdGgV6drvij2Ay-tCHqH4NATqk").build()

#     app.add_handler(CommandHandler("start", start))
#     app.add_handler(CommandHandler("delete", delete_audio))  # Добавляем обработчик для команды /delete
#     app.add_handler(CallbackQueryHandler(vote_callback))
#     app.add_handler(MessageHandler(filters.AUDIO | filters.Document.AUDIO, handle_audio))

#     app.run_polling()

# if __name__ == "__main__":
#     main()

import json
import os
import datetime
from telegram import Update, InlineKeyboardButton, InlineKeyboardMarkup
from telegram.ext import ApplicationBuilder, CommandHandler, MessageHandler, CallbackQueryHandler, filters, ContextTypes

trusted_users = {"smmlt"}
votes = {}

def is_trusted(user):
    return user.id in trusted_users or (user.username in trusted_users if user.username else False)

def log_unauthorized_access(user):
    log_file = "unauthorized_access.json"
    current_time = datetime.datetime.now().strftime("%Y-%m-%d %H:%M:%S")

    entry = {
        "Имя": user.first_name,
        "Юзернейм": user.username,
        "Юзер ID": user.id,
        "Дата и время": current_time
    }

    if os.path.exists(log_file):
        with open(log_file, "r", encoding="utf-8") as f:
            try:
                data = json.load(f)
            except json.JSONDecodeError:
                data = []
    else:
        data = []

    data.append(entry)

    with open(log_file, "w", encoding="utf-8") as f:
        json.dump(data, f, ensure_ascii=False, indent=4)

    print(f"Попытка доступа: {entry}")

# /start и /меню
async def start(update: Update, context: ContextTypes.DEFAULT_TYPE):
    await media_menu(update, context)

async def media_menu(update: Update, context: ContextTypes.DEFAULT_TYPE):
    user = update.effective_user
    if not is_trusted(user):
        log_unauthorized_access(user)
        await update.message.reply_text(
            "🚫 У тебя нет доступа к использованию этого бота.\n\n"
            "Если хочешь получить доступ — напиши [@smmlt](https://t.me/smmlt).",
            parse_mode="Markdown"
        )
        return

    context.user_data.clear()
    await update.message.reply_text(
        f"{user.first_name}!\n\n"
        "Какое сообщение хочешь отправить в [VibeHub](https://t.me/vibehub_chanel)?\n\n"
        "Выбери из вариантов ниже:",
        parse_mode="Markdown",
        disable_web_page_preview=True,
        reply_markup=InlineKeyboardMarkup([
            [InlineKeyboardButton("📷 Отправить фото", callback_data="choose_photo")],
            [InlineKeyboardButton("🎥 Отправить видео", callback_data="choose_video")],
            [InlineKeyboardButton("🎵 Отправить аудио", callback_data="choose_audio")],
        ])
    )

# /cancel
async def cancel(update: Update, context: ContextTypes.DEFAULT_TYPE):
    user = update.effective_user
    if not is_trusted(user):
        log_unauthorized_access(user)
        return

    context.user_data.clear()
    await update.message.reply_text("❌ Действие отменено.\n\nВыбери, что хочешь отправить:")
    await media_menu(update, context)

# Выбор медиа
async def media_choice_callback(update: Update, context: ContextTypes.DEFAULT_TYPE):
    query = update.callback_query
    user = update.effective_user
    await query.answer()
    if not is_trusted(user):
        log_unauthorized_access(user)
        return

    emojis = {"photo": "📷 фото", "video": "🎥 видео", "audio": "🎵 аудио"}
    choice = query.data.replace("choose_", "")
    context.user_data["awaiting_type"] = choice
    await query.message.reply_text(f"Отлично! Теперь отправь {emojis[choice]} — я оформлю его красиво и добавлю в канал!")

# Обработка медиа
async def handle_media(update: Update, context: ContextTypes.DEFAULT_TYPE):
    user = update.effective_user
    if not is_trusted(user):
        await update.message.reply_text(
            "🚫 У тебя нет доступа к использованию этого бота.\n\n"
            "Если хочешь получить доступ — напиши [@smmlt](https://t.me/smmlt).",
            parse_mode="Markdown"
        )
        return

    media_type = context.user_data.get("awaiting_type")
    if not media_type:
        await update.message.reply_text("⚠️ Сначала выбери тип контента через /меню.")
        return

    caption = "Что думаешь про это? Поддержи реакцией ниже!\n\n[VibeHub — музыкальный канал](https://t.me/vibehub_chanel)"
    keyboard = InlineKeyboardMarkup([
        [
            InlineKeyboardButton("❤️ 0", callback_data='vote_heart'),
            InlineKeyboardButton("🔥 0", callback_data='vote_fire'),
        ]
    ])

    media = None
    user_msg = None
    channel_msg = None
    channel_id = "@vibehub_chanel"

    if media_type == "photo" and update.message.photo:
        media = update.message.photo[-1].file_id
        user_msg = await update.message.reply_photo(
            photo=media,
            caption=caption,
            parse_mode='Markdown',
            reply_markup=keyboard
        )
        channel_msg = await context.bot.send_photo(
            chat_id=channel_id,
            photo=media,
            caption=caption,
            parse_mode='Markdown',
            reply_markup=keyboard
        )

    elif media_type == "video" and update.message.video:
        media = update.message.video.file_id
        user_msg = await update.message.reply_video(
            video=media,
            caption=caption,
            parse_mode='Markdown',
            reply_markup=keyboard
        )
        channel_msg = await context.bot.send_video(
            chat_id=channel_id,
            video=media,
            caption=caption,
            parse_mode='Markdown',
            reply_markup=keyboard
        )

    elif media_type == "audio" and (update.message.audio or update.message.document):
        media = update.message.audio.file_id if update.message.audio else update.message.document.file_id
        user_msg = await update.message.reply_audio(
            audio=media,
            caption=caption,
            parse_mode='Markdown',
            reply_markup=keyboard
        )
        channel_msg = await context.bot.send_audio(
            chat_id=channel_id,
            audio=media,
            caption=caption,
            parse_mode='Markdown',
            reply_markup=keyboard
        )

    else:
        await update.message.reply_text(f"⚠️ Пожалуйста, отправьте корректное {media_type}.")
        return

    # Сохраняем голоса
    votes[user_msg.message_id] = {'heart': 0, 'fire': 0, 'channel_msg_id': channel_msg.message_id}
    votes[channel_msg.message_id] = {'heart': 0, 'fire': 0, 'user_msg_id': user_msg.message_id}
    context.user_data.clear()

    await media_menu(update, context)

# Голосование
async def vote_callback(update: Update, context: ContextTypes.DEFAULT_TYPE):
    query = update.callback_query
    user = update.effective_user
    message_id = query.message.message_id
    data = query.data

    if message_id not in votes:
        votes[message_id] = {'heart': 0, 'fire': 0, 'voted_users': set()}

    if not is_trusted(user) and user.id in votes[message_id].get('voted_users', set()):
        await query.answer("⚠️ Вы уже голосовали за этот контент!", show_alert=True)
        return

    if is_trusted(user):
        await query.answer("✅ Голос учтён.")
    else:
        await query.answer("Спасибо! Ваш голос важен!")

    if data == 'vote_heart':
        votes[message_id]['heart'] += 1
    elif data == 'vote_fire':
        votes[message_id]['fire'] += 1

    if not is_trusted(user):
        votes[message_id].setdefault('voted_users', set()).add(user.id)

    keyboard = [
        [
            InlineKeyboardButton(f"❤️ {votes[message_id]['heart']}", callback_data='vote_heart'),
            InlineKeyboardButton(f"🔥 {votes[message_id]['fire']}", callback_data='vote_fire'),
        ]
    ]

    try:
        await query.edit_message_reply_markup(reply_markup=InlineKeyboardMarkup(keyboard))
    except Exception as e:
        print(f"Ошибка обновления кнопок: {e}")

    linked_id = votes[message_id].get('channel_msg_id') or votes[message_id].get('user_msg_id')
    if linked_id:
        try:
            await context.bot.edit_message_reply_markup(
                chat_id='@vibehub_chanel' if update.effective_chat.type != 'channel' else query.message.chat_id,
                message_id=linked_id,
                reply_markup=InlineKeyboardMarkup(keyboard)
            )
        except Exception as e:
            print(f"Ошибка обновления второго сообщения: {e}")

# Удаление
async def delete_audio(update: Update, context: ContextTypes.DEFAULT_TYPE):
    user = update.effective_user
    if not is_trusted(user):
        log_unauthorized_access(user)
        await update.message.reply_text(
            "🚫 У тебя нет доступа к удалению контента.\n\n"
            "Если хочешь получить доступ — напиши [@smmlt](https://t.me/smmlt).",
            parse_mode="Markdown"
        )
        return

    if update.message.reply_to_message:
        msg = update.message.reply_to_message
        await msg.delete()
        await update.message.reply_text("🗑 Контент удалён из чата.")
        try:
            linked_id = votes.get(msg.message_id, {}).get('channel_msg_id')
            if linked_id:
                await context.bot.delete_message(chat_id="@vibehub_chanel", message_id=linked_id)
                await update.message.reply_text("🗑 Контент также удалён из канала.")
        except Exception as e:
            await update.message.reply_text(f"⚠️ Ошибка удаления в канале: {e}")
    else:
        await update.message.reply_text("Ответьте на сообщение с медиа, чтобы удалить его.")

# Фоновая задача: сообщение в консоль каждые 5 минут
async def bot_status_task():
    while True:
        await asyncio.sleep(300)  # 5 минут
        print("⏳ User Info bot работает исправно")

# Запуск
def main():
    app = ApplicationBuilder().token("8094053897:AAEjy48PESdGgV6drvij2Ay-tCHqH4NATqk").build()
    app.add_handler(CommandHandler("start", start))
    app.add_handler(CommandHandler("menu", media_menu))
    app.add_handler(CommandHandler("cancel", cancel))
    app.add_handler(CommandHandler("delete", delete_audio))
    app.add_handler(CallbackQueryHandler(media_choice_callback, pattern="^choose_"))
    app.add_handler(CallbackQueryHandler(vote_callback))
    app.add_handler(MessageHandler(filters.PHOTO | filters.VIDEO | filters.AUDIO | filters.Document.AUDIO, handle_media))

    print("✅ Vibe Hub bot запущен")


    app.run_polling()

if __name__ == "__main__":
    main()

    #   8094053897:AAEjy48PESdGgV6drvij2Ay-tCHqH4NATqk