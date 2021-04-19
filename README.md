# ReadingIsGood
ReadingIsGood - Online Books Retail

To run the project, you will need the following tools;
- Visual Studio 2019
- .Net 5.0 or later
- Docker Desktop

To Install the project;
- Clone the repository
- Open Docker for Windows. Go to the Settings > Advanced option, from the Docker icon in the system tray, to configure the minimum amount of memory and CPU like so:
Memory: 4 GB
CPU: 2
- At the root directory of the project which include docker-compose.yml files, run below command:
docker-compose -f docker-compose.yml -f docker-compose.override.yml up -d

After the microservice, database and portainer are composed, you can launch the following services;

- RIG.API = http://localhost:7001/swagger/index.html
- Portainer (Container Management) = http://localhost:9000/
	- Username= admin
	- Password = admin1234
