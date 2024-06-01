# Бэкенд группового проекта "PetConnect"

## Настройка базы данных в pgAdmin
1. Откройте pgAdmin.
2. Перейдите в Servers -> PostgreSQL.
3. Щелкните правой кнопкой мыши на PostgreSQL и выберите Создать -> База данных.
4. Заполните необходимые поля для создания новой базы данных.

## Настройка конфигурации в appsettings.json:
```json
{
  "Logging": {
    "LogLevel": {
      "Default": "Information",
      "Microsoft.AspNetCore": "Warning"
    }
  },
  "AllowedHosts": "*",
  "ServiceName": "PetConnectService",
  "MonitoringUri": "",
  "ConnectionStrings": {
    "DefaultConnection": "Host=localhost;Port=5432;Database=pet_connect;User Id=postgres;Password=root;" // Поменять при необходимости
  },
  "Jwt": {
    "Key": "hFbYOaOPUjW83ngQKo6LMpfC3FMgqzn0fBFEIFB0fHbBVWj6zAP05K2oHyooBKfpMgXeqW9BcfjJg0QNlWF2nvDtn5ZffmDHynKrvlisOQcz0BU3cInHMGAHo72g4oIO", // Поменять при необходимости
    "Issuer": "PetConnect",
    "Audience": "localhost",
    "ExpiryMinutes": 1440
  },
  "PasswordOptions": {
    "Salt": "Salt" 
  }
}
```
### Подключение к базе данных
+ Host: localhost
+ Port: Порт, указанный при установке pgAdmin
+ Database: Название базы данных
+ User Id: Владелец, указанный при создании базы данных
+ Password: Пароль владельца
  
## Запуск проекта
1. Клонируйте репозиторий на свой локальный компьютер.
2. Настройте appsettings.json согласно описанию выше.
3. Правой кнопкой по решению -> Собрать.
4. В качестве запускаемого проекта установить PetConnect.Backend.Service

## Swagger
Документация API доступна по адресу:
> http://localhost:8001/index.html
