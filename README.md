# 🚀 Установка и запуск проекта

## 📦 Требования

- .NET9 SDK
- Docker (для RabbitMQ)
- SQLite (встроенная поддержка)
- RabbitMQ (локально или в контейнере)

---

## 🔧 Установка и запуск сервисов

1. **Клонируйте репозиторий:**

```bash
git clone https://github.com/Kerven22/src.git
```

2. **Запустите RabbitMQ через Docker:**

docker run -d --hostname rabbit-host --name rabbitmq \
  -p 5672:5672 -p 15672:15672 \
  rabbitmq:3-management


3. **Настройка подключения к RabbitMQ:**
В appsettings.json:

"RabbitMQ": {
  "Host": "localhost",
  "Port": 5672,
  "Username": "guest",
  "Password": "guest",
  "QueueName": "your-queue-name"
}


4. **Инициализация базы данных SQLite**
    Добавьте NuGet-пакет:

```bash
    dotnet add package Microsoft.EntityFrameworkCore.Sqlite
```

 5. **Запуск приложени**
    ```bash
    dotnet run
    ```
