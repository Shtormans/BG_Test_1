BGRunner - простой пример жанра Runner в 3D, в котором игрок бежит по трём полосам постоянно рандомно генерирующегося пути с препятствиями.
Избежать препятствия можно используя 4 движения:
  1. Свайп вправо: переместить персонажа на одну линию правее;
  2. Свайп влево: переместить персонажа на одну линию правее;
  3. Свайп вниз: скольжение персонажа;
  4. Свайп вверх: прыжок.

Используемые SDK и библиотеки:
  1. Firebase - для аутентификация и хранилища данных;
  2. DOTween - для плавной анимации UI и персонажа;
  3. AdMob - для создания рекламы.

<h3>Детали игрового процесса<h3>

С самого начала игрока встретит форма авторизации (состоит из ввода Email и пароля)
<a href="https://imgur.com/Yy8Wzeb"><img src="https://i.imgur.com/Yy8Wzeb.jpg" title="source: imgur.com" /></a>

Если же игрок не авторизирован, то на этот случай есть форма регистрации (Включает в себя Username, Email, пароль и повторный ввод пароля)
<a href="https://imgur.com/O7d08el"><img src="https://i.imgur.com/O7d08el.jpg" title="source: imgur.com" /></a>

После авторизации игрока, перед ним будет экран с leaderboard и кнопками выхода из аккаунта и из игры.
<a href="https://imgur.com/pyssQrv"><img src="https://i.imgur.com/pyssQrv.jpg" title="source: imgur.com" /></a>

Примеры игрового процесса
<a href="https://imgur.com/JiqK20F"><img src="https://i.imgur.com/JiqK20F.jpg" title="source: imgur.com" /></a>
<a href="https://imgur.com/yiSpg9R"><img src="https://i.imgur.com/yiSpg9R.jpg" title="source: imgur.com" /></a>
<a href="https://imgur.com/tR1EqZq"><img src="https://i.imgur.com/tR1EqZq.jpg" title="source: imgur.com" /></a>

После смерти игрока, у него есть выбор возродиться, используя возрождение за рекламу (но это одноразовая акция на забег)
<a href="https://imgur.com/G4nZMOq"><img src="https://i.imgur.com/G4nZMOq.jpg" title="source: imgur.com" /></a>

После возрождения часть препятствий будет уничтожены для аклиматизации игрока.
