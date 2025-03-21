function downloadFile(base64Data, fileName, contentType) {
    const link = document.createElement('a');
    link.href = `data:${contentType};base64,${base64Data}`;
    link.download = fileName;
    link.click();
}
