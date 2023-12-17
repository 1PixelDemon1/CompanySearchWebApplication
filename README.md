
# CompanySearchWebApplication


## Русский
Веб-приложение предназначено для поиска компании на различные события. В приложение могут добавляться произвольные пользовательские и коммерческие события, другие пользователи могут входить в состав участников событий.
Коммерческие и пользовательские события могут ссылаться друг на друга: например, на коммерческое событие «Cheese Quiz» искать компанию могут сразу несколько разных людей – будет несколько пользовательских событий, и одно пользовательское событие может включать несколько коммерческих и пользовательских (сначала сходим в кино, потом в бар).
При добавлении события пользователь может прикреплять к нему существующие категории или создавать собственные. Категории иерархичные (например, «Спорт» => «Хоккей»). К одному событию можно прикреплять несколько категорий разных уровней. При редактировании события пользователь может изменять состав категорий.

Приложение построено на чистой архитектуре(clean architecture) с применением паттернов:
* Репозиторий (Repository)
* Единица работы (Unit Of Work)
* CQRS
## Развертывание

Для того, чтобы развернуть приложение необходимо установить [Docker](https://www.docker.com/).
* Затем необходимо установить файл [docker-compose.yaml](docker-compose.yaml) из репозитория.
* По расположению файла запустить контейнеры docker при помощи следующей консольной команды:
```bash
  docker-compose up
```

## Тестирование
После запуска контейнеров на localhost по порту 80 будет работать web api, работу с которой можно протестировать при помощи swagger на странице:

    https://localhost/swagger/index.html
## English
The web application is designed to search for a company for various events. User events and commercial events can be added to the application, and other users can be signed to the event.
Commercial and user events can link to each other: for example, several different people can search for a company at once for the commercial event "Cheese Quiz" – there will be several user events, and one user event may include several commercial and user events (first we go to the cinema, then to the bar).
When adding an event, the user can attach existing categories to it or create their own. The categories are hierarchical (for example, "Sports" => "Hockey"). Several categories of different levels can be attached to one event. When editing an event, the user can change the composition of categories.

Application is build on a clean architecture using following patterns:
* Repository
* Unit Of Work
* CQRS
## Deployment

To deploy the app you have to install [Docker](https://www.docker.com/).
* Then you need to download [docker-compose.yaml](docker-compose.yaml) from this repo.
* By file location, launch docker containers using the following console command:
```bash
  docker-compose up
```

## Testing
When containers are launched the web api will work on localhost port 80, which can be tested using swagger on this page:

    https://localhost/swagger/index.html
