<h3>Web API  </h3>

для службы доставки, которое фильтрует заказы в зависимости от
количества обращений в конкретном районе города и времени обращения с и по.

Выводится результат фильтрации
заказов для доставки в конкретный район города в ближайшие полчаса после времени первого заказа.

 <strong>О приложении:</strong>
  <ul>
  <li>Для проверки приложения используется район=2, дата = 2024-10-25 16:20:00</li>
  <li>База данных использовал SQL lite, посмотреть данные можно в классе DbInitializer;</li>
  <li>Для записи логов использованил package Serilog.Extensions.Logging.File. Логи пишутся в Logs/log-{дата}.txt</li>
      <li>Для тестов использовал XUnit;</li>      
</ul>

 <strong>API</strong>

Получение заказов, для конкретного района и даты +30 минут : GET /get-orders-after-date
 
