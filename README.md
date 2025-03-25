# PrototypeAssembler
Это программа для сборки прототипов [space station 14](https://github.com/space-wizards/space-station-14) вместе.

## Текущий статус
Сейчас в разработке. Ещё нужно доработать сборщик, так как сейчас нет абстрактного `IFileCollector` и файлы для сборки определяются в конструкторе класса сборщика и он там на уровне заглушки. Также ещё нет UI Оболочки.

## Зачем он нужен?
Предназначен он в первую очередь, для тех, кто создаёт большие, объёмные, ивентовые прототипы. Так как обработчик прототипов SS14 может обрабатвать несколько прототипов в одном файле, но загружаются в рантайме только отдельные файлы, создание ивентовых прототипов для загрузки в рантайм в виде множества разделённых между собой файлов не представляется возможным в силу сложностей с их последущей загрузкой (каждый по отдельности придётся грузить). Все создают 1 моно файл, со всеми ивентовыми прототипами, что крайне неудобно для разработки, так как всё находится в одном файле и это то же самое, если разрабатывать большую программу в один файл. Для того, чтобы можно было разрабатывать ивентовые, крупные, прототипы как и обычные прототипы для добавления в игру, я рещил сделать эту программу, чтобы все прототипы можно было логически разбивать на отдельные файлы которые потом, при особом желании, можно будет с лёгкостью отправить в репозиторий самой игры, без изменения содержимого файлов.

## Как пользоваться
На будущее: когда оформлю проект как следует, распишу как им пользоваться. Сейчас он даже не доделан

## Установка
На будущее: когда оформлю проект как следует, распишу как установить. Пока-что просто скачайте исходный код, скомпилируйте и запустите с параметрами `Content.Core`. 

## Устройство проекта
Устройство проекта подразумевает основу-сборщик, которая ожидает на вход параметры, после чего выполняет свою работу. Она подразумевает наличие UI оболочки для удобной работы с ним, которая будет вызывать его с параметрами. Это нужно для того, чтобы сам механизм сборки не зависил от конкретной реализации UI оболочки.

### Content.Core
Это - ядро проекта. Именно там выполняется логика сборки.

#### Входные параметры
- Информация для сборки:
  - Путь до рабочей папки, в которой лежат прототипы.
  - Автор (опционально)
  - Добавлять ли автора?(Опционально); TODO: лучше убрать это и проверять, задан ли автор.

- Информация для сохранения:
  - Путь сохранения собранного файла.

#### Результат
- Собранный файл с прототипами в формате `.yml`.

### Content.SimpleUIShell [В РАЗРАБОТКЕ]
Это простая UI оболочка написанная на WinForms. Ничего особенного, просто базовый, минимальный интерфейс для сборки файлов.

Сейчас в разработке

## Планы на будущее
В будущем планируется расширить функционал программы, чтобы она могла полностью собирать ивентовые прототипы, начиная от прототипов, заканчивая звуками.

Также, я бы хотел добавить возможность вызывать его с параметрами через консоль, с флагами и так далее.

## FAQ
- Q: Зачем всё так переусложнено, зачем столько абстракций?
- A: Так правильно. Я мог, конечно, написать всю логику в методе Main, но это было бы неправильно. А так модульный код, я бы даже ещё добавил в систему `IFileCollector` с его реализацией, так как сейчас файлы для сборки собирает сам `IAssembler` у себя в конструкторе 💀. Сейчас вы можете без особых проблем написать свою реализацию `IAssembler` или `ISaver`, чтобы изменить их внутреннюю логику. Вообще, я задумывал этот проект как более-менее крупный, так что без абстракций никуда, иначе в будущем придётся морочится с тем, что у нас класс на 1.000 строк 💀
