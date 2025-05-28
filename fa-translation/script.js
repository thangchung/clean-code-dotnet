// script.js

document.addEventListener("DOMContentLoaded", () => {
    const themeToggleBtn = document.getElementById("theme-toggle");
    const body = document.body;

    // تابع برای اعمال تم
    const applyTheme = (theme) => {
        if (theme === "dark") {
            body.classList.add("dark-mode");
        } else {
            body.classList.remove("dark-mode");
        }
    };

    // بررسی تم ذخیره شده در Local Storage یا تنظیم تم پیش‌فرض
    const savedTheme = localStorage.getItem("theme");
    if (savedTheme) {
        applyTheme(savedTheme);
    } else {
        // اگر تمی ذخیره نشده، تم سیستم کاربر را بررسی کنید
        if (
            window.matchMedia &&
            window.matchMedia("(prefers-color-scheme: dark)").matches
        ) {
            applyTheme("dark");
        } else {
            applyTheme("light");
        }
    }

    // اضافه کردن Listener برای دکمه تغییر تم
    themeToggleBtn.addEventListener("click", () => {
        if (body.classList.contains("dark-mode")) {
            applyTheme("light");
            localStorage.setItem("theme", "light");
        } else {
            applyTheme("dark");
            localStorage.setItem("theme", "dark");
        }
    });

    // اضافه کردن استایل برای دکمه (می‌تواند در CSS هم باشد)
    themeToggleBtn.style.background = "none";
    themeToggleBtn.style.border = "none";
    themeToggleBtn.style.cursor = "pointer";
    themeToggleBtn.style.fontSize = "1.8rem";
    themeToggleBtn.style.marginLeft = "1rem"; /* فاصله از منو */
    themeToggleBtn.style.padding = "0.5rem";
    themeToggleBtn.style.color = "var(--text-color)"; /* رنگ آیکون */
    themeToggleBtn.style.transition = "color 0.3s ease";

    // بهبودهای دیگر (مثلا برای آیکون‌های خورشید/ماه)
    const updateThemeIcon = () => {
        if (body.classList.contains("dark-mode")) {
            themeToggleBtn.innerHTML = "🌙"; // آیکون ماه برای تم تاریک
        } else {
            themeToggleBtn.innerHTML = "☀️"; // آیکون خورشید برای تم روشن
        }
    };

    // در ابتدا آیکون را به‌روزرسانی کنید
    updateThemeIcon();

    // هر بار که تم تغییر می‌کند، آیکون را نیز به‌روزرسانی کنید
    themeToggleBtn.addEventListener("click", updateThemeIcon);
});
