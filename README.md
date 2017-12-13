# Компонент
Это капча, исполненая в виде графической мини-игры с простым интерфейсом.

[NuGet](https://www.nuget.org/packages/HumanVerification)

## Применение компонента

* Компонент служит средством верификации пользователя на использование бот-программ
* Компонент защищает приложение от спама и злоупотреблений совершения одного и того же действия
* Компонент будет проверять пользователя под средством перетаскивания дочерних элементов на главный элемент формы
* Компонент будет возвращать результат в зависимости от корректности прохождения проверки

## Установка

* Скачать компонент с NuGet.org
* ПКМ по любой вкладке ToolBox -> Выбрать элементы -> Компоненты .NET FrameWork -> Обзор -> выбрать MainComponent.dll в директории название_проекта/bin/Debug/ 

## Использование

* Добавить элемент на форму
* Настроить при необходимости, используя свойства
* Использовать компонент согласно примеру
#### Пример
```C#
if (humanVerification1.Result) 
    textBox1.Enabled = true;
```

## Свойства

###	`BackgroundImage`
Позволяет загружать собственное изображение на фон компонента.
###	`BackgroundImagePrimary`
Позволяет измененять изображение главного компонента.
###	`CaptchaPattern`
Позволяет выбирать шаблоны для капчи (Face, Refrigerator, Flower).
###	`ColorLine`
Позволяет изменять цвет обводки компонента.
###	`CountRightChild`
Позволяет изменять количество правильных дочерних элементов.
###	`CountWrongChild`
Позволяет изменять количество не правильных дочерних элементов.
###	`ErrorNumber`
Позволяет изменять количество возможно допустимых ошибок.
###	`PathRightChildPicture`
Позволяет загружать собственные изображения на правильные дочерние элементы.
###	`PathWrongChildPicture`
Позволяет загружать собственные изображения на не правильные дочерние элементы.
###	`TextHelp`
Позволяет изменять справку по работе с компонентом для пользователя.
###	`Result`
Возращает значение `true/false` в зависимости от результата проверки.


