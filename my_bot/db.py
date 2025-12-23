import sqlite3

DB_NAME = 'votes.db'

def init_db():
    conn = sqlite3.connect(DB_NAME)
    cursor = conn.cursor()
    cursor.execute('''
        CREATE TABLE IF NOT EXISTS votes (
            message_id INTEGER PRIMARY KEY,
            heart INTEGER DEFAULT 0,
            fire INTEGER DEFAULT 0
        )
    ''')
    conn.commit()
    conn.close()

def save_vote(message_id, heart, fire):
    conn = sqlite3.connect(DB_NAME)
    cursor = conn.cursor()
    cursor.execute('''
        INSERT INTO votes (message_id, heart, fire)
        VALUES (?, ?, ?)
        ON CONFLICT(message_id) DO UPDATE SET heart=excluded.heart, fire=excluded.fire
    ''', (message_id, heart, fire))
    conn.commit()
    conn.close()

def get_votes(message_id):
    conn = sqlite3.connect(DB_NAME)
    cursor = conn.cursor()
    cursor.execute('SELECT heart, fire FROM votes WHERE message_id = ?', (message_id,))
    row = cursor.fetchone()
    conn.close()
    if row:
        return {'heart': row[0], 'fire': row[1]}
    return None

def delete_votes(message_id):
    conn = sqlite3.connect(DB_NAME)
    cursor = conn.cursor()
    cursor.execute('DELETE FROM votes WHERE message_id = ?', (message_id,))
    conn.commit()
    conn.close()