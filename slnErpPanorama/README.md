## Configuración para generar clave SSH (autoriza tu equipo)

1. **Generar una clave SSH:** Abre tu terminal y ejecuta el siguiente comando para generar una nueva clave SSH:

```bash
ssh-keygen -t ed25519 -C "panorama.sistemas2023@gmail.com"
```
2. Ejecuta el siguiente comando para agregar tu clave SSH al agente SSH en tu equipo:
```bash
eval "$(ssh-agent -s)"
ssh-add ~/.ssh/id_ed25519
```

3. Copiar la clave SSH: Ejecuta el siguiente comando para copiar tu clave SSH al portapapeles:
```bash
cat ~/.ssh/id_ed25519.pub
```
