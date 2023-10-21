FROM python:3.11.6-alpine3.17
LABEL authors="feelin"

WORKDIR /usr/src/app

COPY . /usr/src/app

RUN pip install -r requirements.txt

ENTRYPOINT ["python3", "main.py"]