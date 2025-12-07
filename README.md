# ? OlehLinuxUtils  
## **Міні-набір Linux-утиліт (`sort`, `tail`) реалізований на C# (.NET 8)**

OlehLinuxUtils — це легка кросплатформна CLI-бібліотека, що реалізує популярні Unix-команди **sort** та **tail**, але написана повністю мовою **C#** з використанням **.NET 8** та **Spectre.Console.Cli**.

Це зручний інструмент для роботи з текстовими файлами, логами, даними, а також навчальний приклад того, як створювати *власні Linux-утиліти на C#*.

---

# ??? Вимоги до апаратного забезпечення

Для роботи інструменту потрібно мінімум:

- **CPU:** будь-який 64-бітний процесор (Intel / AMD / ARM64)  
- **RAM:** 50 МБ або більше  
- **Disk:** 20 МБ на диск (місце для інструменту + тимчасові файли .NET)  
- **OS:**  
  - Windows 10 / 11  
  - Linux Ubuntu / Debian / Arch / Fedora  
  - macOS (Intel або ARM)

?? *Програма дуже легка і працює практично на будь-якому сучасному ПК або ноутбуці.*

---

# ?? Вимоги до версій програмного забезпечення

Потрібно встановити:

- **.NET SDK 8.0 або новіше**  
  Завантажити: https://dotnet.microsoft.com/en-us/download

Перевірити встановлену версію:

```
dotnet --version
```





8.0.x


---

# ?? Встановлення

Оскільки утиліта поширюється **через GitHub**, а не через NuGet, встановлення виконується локально.

---

## 1?? Клонувати репозиторій

```bash
git clone https://github.com/<YourUser>/OlehLinuxUtils.git
cd OlehLinuxUtils

2?? Зібрати пакет
dotnet pack -c Release


Після цього файл пакета буде знаходитися тут:

src/OlehLinuxUtils/bin/Release/*.nupkg

3?? Створити папку для локальних пакетів
mkdir nupkg

4?? Скопіювати .nupkg
copy .\src\OlehLinuxUtils\bin\Release\*.nupkg .\nupkg\

5?? Встановити CLI-інструмент
dotnet tool install -g OlehLinuxUtils --add-source ./nupkg

6?? Перевірити встановлення
oleh-linux --help


?? Тепер доступні дві команди:

oleh-linux sort
oleh-linux tail

?? Використання програми
?? Загальний синтаксис
oleh-linux <command> [options] [files...]


Доступні команди:

Команда	Опис
sort	Сортує рядки тексту
tail	Виводить останні N рядків
?? Команда sort

Утиліта аналогічна Linux-команді sort.

?? Підтримувані параметри
Параметр	Опис
-n, --numeric	Числове сортування
-r, --reverse	Зворотний порядок
-h, --help	Показати довідку
?? Приклади
?? Звичайне сортування тексту
oleh-linux sort names.txt

?? Числове сортування
oleh-linux sort -n numbers.txt

?? Зворотне сортування
oleh-linux sort -r data.txt

?? Через stdin
cat values.txt | oleh-linux sort -

?? Числове + зворотне
oleh-linux sort -n -r values.txt

?? Команда tail

Аналог команди tail -n.

?? Параметри
Параметр	Опис
-n <число>, --lines <число>	Кількість рядків (за замовчуванням 10)
-h, --help	Показати довідку
?? Приклади використання
?? Останні 10 рядків (за замовчуванням)
oleh-linux tail logfile.txt

?? Останні 20 рядків
oleh-linux tail -n 20 logfile.txt

?? Використання stdin
cat huge.log | oleh-linux tail -n 5 -

?? Структура проєкту
OlehLinuxUtils/
 ?? src/
 ?   ?? OlehLinuxUtils/
 ?        ?? Commands/
 ?        ?     ?? SortCommand.cs
 ?        ?     ?? TailCommand.cs
 ?        ?? Utils/
 ?        ?     ?? FileReader.cs
 ?        ?? Program.cs
 ?        ?? OlehLinuxUtils.csproj
 ?? nupkg/
 ?? README.md
 ?? LICENSE

?? Ліцензія

Проєкт розповсюджується за MIT License — можна використовувати у будь-яких цілях.

?? Автор

Oleh
Студентський навчальний проєкт із розробки Unix-like CLI утиліт мовою C#.



