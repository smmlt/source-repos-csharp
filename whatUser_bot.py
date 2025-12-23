from telegram import Update, KeyboardButton, ReplyKeyboardMarkup
from telegram.ext import (
    Application,
    CommandHandler,
    MessageHandler,
    ContextTypes,
    filters,
)
import logging

trusted_users = {"smmlt", 1151324279}

def is_trusted(user):
    return user.id in trusted_users or (user.username in trusted_users if user.username else False)

async def start(update: Update, context: ContextTypes.DEFAULT_TYPE):
    user = update.effective_user

    response = f"Имя: {user.first_name}"
    if user.last_name:
        response += f" {user.last_name}"
    if user.username:
        response += f"\nUsername: @{user.username}"
    response += f"\nUser ID: {user.id}"
    response += "\n\nЕсли хочешь, отправь свой контакт, и я покажу номер телефона."

    button = KeyboardButton("Отправить мой номер", request_contact=True)
    keyboard = ReplyKeyboardMarkup([[button]], resize_keyboard=True, one_time_keyboard=True)
    await update.message.reply_text(response, reply_markup=keyboard)

async def handle_contact(update: Update, context: ContextTypes.DEFAULT_TYPE):
    user = update.effective_user

    if not is_trusted(user):
        await update.message.reply_text("У тебя нет доступа к этой функции.")
        return

    contact = update.message.contact
    response = "Получен контакт:\n"
    response += f"Имя: {contact.first_name}"
    if contact.last_name:
        response += f" {contact.last_name}"
    response += f"\nТелефон: {contact.phone_number}"
    response += f"\nUser ID: {contact.user_id}" if contact.user_id else "\nUser ID: недоступен"

    await update.message.reply_text(response)

# Эта функция будет вызываться каждые 5 минут
async def status_log(context: ContextTypes.DEFAULT_TYPE):
    print("⏳ User Info bot работает исправно")

def main():
    app = Application.builder().token("7708041739:AAEUPuOxSXPoxCCeJcBEJ3kDcKLwPX1ADyU").build()

    app.add_handler(CommandHandler("start", start))
    app.add_handler(MessageHandler(filters.CONTACT, handle_contact))

    print("✅ User Info bot запущен")


    app.run_polling()

if __name__ == "__main__":
    main()
