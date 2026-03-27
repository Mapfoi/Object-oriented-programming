
# 🚀 Roadmap изучения DevOps (6 месяцев)

Формат: теория → сразу практика уровня “как в проде”.  
Дополнено ссылками на официальные источники, YouTube-каналы и рекомендации по собеседованиям.

---

# 🟢 Шаг 1 (Месяц 1). Linux и сети

## 1. Linux (операционная система)

### Практика:

- Установить Ubuntu Server без GUI
- Настроить пользователя без root
- SSH по ключам, запрет password auth
- fail2ban
- systemd unit для собственного сервиса
- Bash-скрипт бэкапа и логирования [Exercism](https://exercism.org/tracks/bash)

- Разбор процессов (`top`, `htop`, `ps`, `lsof`)
- Смонтировать второй диск

📚 Теория / документация:

- Linux kernel docs — https://docs.kernel.org  
- systemd docs — https://www.freedesktop.org/wiki/Software/systemd/  
- man7.org — https://man7.org/linux/man-pages/  

---

## 2. TCP/IP (сетевой стек)

### Практика:

- Поднять 2 VM, статические IP, SSH
- NAT-шлюз
- Настроить firewall (открыть 80, закрыть всё остальное)
- `tcpdump` для перехвата трафика
- TLS handshake через `openssl s_client`

📚 Теория:

- IETF RFC — https://datatracker.ietf.org  
- OpenSSH docs — https://www.openssh.com/manual.html  
- nftables — https://wiki.nftables.org  
- MDN HTTP — https://developer.mozilla.org  

---

## 3. KVM (виртуализация)

### Практика:

- Развернуть VM через virt-manager
- Настроить bridged network
- Ограничить CPU/RAM
- Сделать snapshot
- Смоделировать падение VM

📚 Теория:

- https://www.linux-kvm.org  
- https://www.virtualbox.org/wiki/Documentation  

---

## 4. Git (контроль версий)

### Практика:

- Создать monorepo, настроить workflow
- Rebase, squash, resolve конфликты
- Pre-commit hook
- CI pipeline на push

📚 Теория:

- https://git-scm.com/docs  
- https://docs.github.com  
- https://docs.gitlab.com  

---

# 🟢 Шаг 2 (Месяц 2). Docker

## 1. Docker

### Практика:

- Dockerfile, multi-stage build
- Healthcheck
- Ограничение ресурсов
- Проверка слоев через `docker history`
- Несколько экземпляров контейнера

📚 Документация:

- https://docs.docker.com  

---

## 2. Docker Compose

### Практика:

- Стек: backend + postgres + redis + nginx
- Volumes, internal network, env переменные
- Перезапуск при падении

📚 Документация:

- https://docs.docker.com/compose/  

---

## 3. Registry

### Практика:

- Приватный registry
- Push/pull
- Авторизация

---

🎯 Итог: контейнеризация production-ready.

---

# 🟢 Шаг 3 (Месяц 3). Kubernetes

## 1. Kubernetes

### Практика:

- Minikube
- Deployment, Service, ConfigMap, Secret
- Rolling update + rollback
- CPU/memory limits

📚 Документация:

- https://kubernetes.io/docs  

---

## 2. Ingress

### Практика:

- nginx ingress controller
- Host-based routing
- TLS

📚 Документация:

- https://kubernetes.io/docs/concepts/services-networking/ingress/  

---

## 3. HPA

### Практика:

- Настроить CPU requests/limits
- Нагрузочный тест через k6
- Scale up / scale down

📚 Документация:

- https://kubernetes.io/docs/tasks/run-application/horizontal-pod-autoscale/  

---

# 🟢 Шаг 4 (Месяц 4). CI/CD и IaC

## 1. CI/CD

### Практика:

- Pipeline: lint → test → build → push → deploy
- Manual approval stage
- Version tagging
- Rollback job

📚 Документация:

- GitHub Actions docs — https://docs.github.com/actions  
- GitLab CI docs — https://docs.gitlab.com/ee/ci/  
- Jenkins docs — https://www.jenkins.io/doc/  

---

## 2. Terraform

### Практика:

- VPC, EC2, Security Groups
- Modules
- State в S3
- Remote locking

📚 Документация:

- https://developer.hashicorp.com/terraform/docs  

---

## 3. Ansible

### Практика:

- Playbook для установки Docker и пользователя
- Inventory
- Развернуть 3 сервера

📚 Документация:

- https://docs.ansible.com/  

---

# 🟢 Шаг 5 (Месяц 5). Cloud и Observability

## 1. AWS

### Практика:

- EC2, IAM, Load Balancer
- Auto Scaling
- HTTPS через ACM

📚 Документация:

- https://docs.aws.amazon.com  

---

## 2. Prometheus + Grafana

### Практика:

- Установка через Helm
- Node exporter
- Dashboard: CPU, Memory, Pods
- Alerting (Telegram/email)
- Отказ pod

📚 Документация:

- Prometheus — https://prometheus.io/docs/  
- Grafana — https://grafana.com/docs/  

---

## 3. ELK

### Практика:

- Elasticsearch
- Filebeat
- Централизованные логи
- Фильтр error-level
- Поиск ошибки при падении

📚 Документация:

- Elasticsearch — https://www.elastic.co/guide/en/elasticsearch/reference/current/index.html  
- Kibana — https://www.elastic.co/guide/en/kibana/current/index.html  

---

# 🟢 Шаг 6 (Месяц 6). Production

## 1. High Availability

### Практика:

- 2 replicas backend
- LoadBalancer
- Отказ pod / ноды

## 2. Blue/Green deploy

### Практика:

- 2 версии приложения
- Переключение трафика через ingress
- Откат при ошибке

## 3. Canary deploy

### Практика:

- 10% трафика на новую версию
- Метрики
- Автоматический rollback

---

# 🏗 Финальный Production Pet-Project

- Backend API + Postgres
- Docker + Kubernetes
- CI/CD
- Terraform
- Мониторинг + Логирование
- TLS
- README + архитектурная схема
- Разместить на GitHub

---

# 🎥 YouTube-каналы

## Англоязычные

- TechWorld with Nana — Docker, Kubernetes, CI/CD  
- Bret Fisher — Docker, DevOps  
- KodeKloud — Kubernetes, CKA  
- DevOps Toolkit  
- Google Cloud Tech  
- AWS Events  

## Русскоязычные

- ADV-IT  
- DevOps by Rebrain  
- Слёрм  
- IT-KAMASUTRA  
- Hexlet  
- fakng-engineer

---

# 💼 Собеседования / компании

### Минск (Беларусь):

- EPAM — DevOps Engineer / Platform Engineer  
- ITechArt — DevOps / Cloud Engineer  
- Intetics — Remote-friendly DevOps  
- ScienceSoft — Cloud/DevOps Engineer  

### Онлайн / Remote-friendly:

- GitLab — Remote DevOps roles  
- Red Hat — DevOps/SRE  
- HashiCorp — Terraform Engineer  
- Amazon AWS — Cloud/DevOps  
- Google Cloud — SRE / DevOps  

Совет: подготовка к собеседованию через LeetCode (for algorithms), System Design Interviews, и практические задачи на CI/CD + Kubernetes.

---
