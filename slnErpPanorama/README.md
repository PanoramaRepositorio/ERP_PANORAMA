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
4. **Agregar la clave SSH a tu cuenta de GitHub:** Abre GitHub en tu navegador, inicia sesión en tu cuenta y accede a la configuración de tu perfil. Luego, sigue estos pasos:

a. Haz clic en "SSH and GPG keys" (Claves SSH y GPG) en el menú lateral.
b. Haz clic en "New SSH key" (Nueva clave SSH).
c. Proporciona un título descriptivo para la clave SSH, por ejemplo, "Mi clave SSH personal".
d. Pega el contenido de tu clave SSH que copiaste en el portapapeles en el campo "Key" (Clave).
e. Haz clic en "Add SSH key" (Agregar clave SSH) para guardar la clave en tu cuenta de GitHub.

5. Verificar la configuración de la clave SSH: En tu terminal, ejecuta el siguiente comando para verificar si la configuración de tu clave SSH es correcta:

```bash
ssh -T git@github.com
```
