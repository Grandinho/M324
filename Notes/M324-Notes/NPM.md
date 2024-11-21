
- npm: node package manager
- package-lock.json: detaillierte ansicht von Abhängigkeiten
- package.json: alle Abhängikeiten. Hier kann auch ein Startup script definiert werden für npm run "name"


## Commands
npm i - installiert Abhängigkeiten aus package.json
npm ci - installiert die Abhängigkeiten aus package-lock.json. npm installier auch die neuste version mit npm ci wird die version installier die in package-lock.json steht. Mit dem ist man sicher, dass man richtige Abhängigkeiten installiert da sie mit hash überprüft werden.