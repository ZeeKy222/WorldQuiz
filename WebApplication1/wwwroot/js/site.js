// Please see documentation at https://learn.microsoft.com/aspnet/core/client-side/bundling-and-minification
// for details on configuring this project to bundle and minify static web assets.

// Simple settings panel toggle and small interactions
document.addEventListener('DOMContentLoaded', function () {
    var translations = {
        en: {
            general: 'General', profile: 'Profile', display: 'Display', theme: 'Theme', textSize: 'Text Size', about: 'About', version: 'Version',
            language: 'Language', english: 'English', bulgarian: 'Bulgarian', privacy: 'Privacy', startQuiz: 'Start Quiz', pickMode: 'Pick a mode', random: 'Random',
            africa: 'Africa', asia: 'Asia', europe: 'Europe', northAmerica: 'North America', southAmerica: 'South America', australia: 'Australia',
            chooseAnotherMode: '← Choose another mode', flagQuestion: 'Which country does this flag belong to?', previousQuestion: 'Previous question',
            nextQuestion: 'Next question', showResult: 'Show my result', yourResults: 'Your results', flagQuiz: 'flag quiz', perfectScore: 'Perfect score!',
            successRate: 'success rate', scoreCount: '{correct} of {total} correct', question: 'Question {number}',
            youChose: 'You chose', correctSuffix: '— correct!', yourAnswerLabel: 'Your answer:', correctAnswerLabel: 'Correct answer:',
            tryAgain: 'Try again', privacyPolicy: 'Privacy Policy', privacyText: "Use this page to detail your site's privacy policy.", questionCounter: 'Question {current} of {total}'
        },
        bg: {
            general: 'Общи', profile: 'Профил', display: 'Изглед', theme: 'Тема', textSize: 'Размер на текста', about: 'Относно', version: 'Версия',
            language: 'Език', english: 'Английски', bulgarian: 'Български', privacy: 'Поверителност', startQuiz: 'Започни викторината', pickMode: 'Избери режим', random: 'Случаен',
            africa: 'Африка', asia: 'Азия', europe: 'Европа', northAmerica: 'Северна Америка', southAmerica: 'Южна Америка', australia: 'Австралия',
            chooseAnotherMode: '← Избери друг режим', flagQuestion: 'На коя държава принадлежи това знаме?', previousQuestion: 'Предишен въпрос',
            nextQuestion: 'Следващ въпрос', showResult: 'Покажи резултата', yourResults: 'Твоите резултати', flagQuiz: 'викторина със знамена', perfectScore: 'Перфектен резултат!',
            successRate: 'успеваемост', scoreCount: '{correct} от {total} правилни', question: 'Въпрос {number}',
            youChose: 'Твоят отговор е', correctSuffix: '— правилен!', yourAnswerLabel: 'Твоят отговор:', correctAnswerLabel: 'Правилен отговор:',
            tryAgain: 'Опитай отново', privacyPolicy: 'Политика за поверителност', privacyText: 'Използвай тази страница за подробности относно политиката за поверителност.', questionCounter: 'Въпрос {current} от {total}'
        }
    };
    var languageFlag = document.getElementById('languageFlag');
    var panelLanguageFlag = document.getElementById('panelLanguageFlag');
    var languageOptions = document.querySelectorAll('.language-option');
    var languageToggle = document.getElementById('languageToggle');
    var languageOptionsPanel = document.getElementById('languageOptions');
    var pageRoot = document.getElementById('pageRoot');

    function translateTemplate(template, values) {
        return Object.keys(values).reduce(function (result, key) {
            return result.replaceAll('{' + key + '}', values[key]);
        }, template);
    }

    window.worldQuizTranslate = function (key, values) {
        var language = window.worldQuizLanguage || 'en';
        var text = translations[language][key] || translations.en[key] || key;
        return values ? translateTemplate(text, values) : text;
    };

    function applyLanguage(language) {
        var selectedLanguage = translations[language] ? language : 'en';
        window.worldQuizLanguage = selectedLanguage;
        document.querySelectorAll('[data-i18n]').forEach(function (element) {
            var translationKey = element.getAttribute('data-i18n');
            element.textContent = window.worldQuizTranslate(translationKey);
        });
        document.querySelectorAll('[data-i18n-template]').forEach(function (element) {
            var values = {};
            Array.from(element.attributes).forEach(function (attribute) {
                if (attribute.name.indexOf('data-') === 0 && attribute.name !== 'data-i18n-template') {
                    values[attribute.name.substring(5)] = attribute.value;
                }
            });
            element.textContent = window.worldQuizTranslate(element.getAttribute('data-i18n-template'), values);
        });
        var continentKeys = { Africa: 'africa', Asia: 'asia', Europe: 'europe', 'North America': 'northAmerica', 'South America': 'southAmerica', Australia: 'australia', Random: 'random' };
        document.querySelectorAll('.js-continent').forEach(function (element) {
            element.textContent = window.worldQuizTranslate(continentKeys[element.getAttribute('data-continent')] || 'random');
        });
        document.querySelectorAll('.country-name').forEach(function (element) {
            var code = element.getAttribute('data-country-code');
            if (!code) { return; }
            if (!element.hasAttribute('data-original-name')) {
                element.setAttribute('data-original-name', element.textContent);
            }
            try {
                var displayNames = new Intl.DisplayNames([selectedLanguage], { type: 'region' });
                element.textContent = displayNames.of(code.toUpperCase()) || element.getAttribute('data-original-name');
            } catch (error) {
                element.textContent = element.getAttribute('data-original-name');
            }
        });

        var selectedOption = document.querySelector('.language-option[data-language="' + selectedLanguage + '"]');
        if (selectedOption) {
            var flagCode = selectedOption.getAttribute('data-flag');
            var flagUrl = 'https://flagcdn.com/w40/' + flagCode + '.png';
            var flagLabel = selectedOption.getAttribute('data-label');
            if (languageFlag) { languageFlag.src = flagUrl; languageFlag.alt = flagLabel; }
            if (panelLanguageFlag) { panelLanguageFlag.src = flagUrl; panelLanguageFlag.alt = flagLabel; }
        }
        if (pageRoot) { pageRoot.lang = selectedLanguage; }
        localStorage.setItem('worldQuizLanguage', selectedLanguage);
    }

    languageOptions.forEach(function (option) {
        option.addEventListener('click', function () {
            localStorage.setItem('worldQuizLanguage', option.getAttribute('data-language'));
            window.location.reload();
        });
    });
    if (languageToggle && languageOptionsPanel) {
        languageToggle.addEventListener('click', function (event) {
            event.stopPropagation();
            languageOptionsPanel.classList.toggle('visible');
        });
    }
    applyLanguage(localStorage.getItem('worldQuizLanguage') || 'en');

    var settingsToggle = document.getElementById('settingsToggle');
    var settingsPanel = document.getElementById('settingsPanel');
    if (settingsToggle && settingsPanel) {
        settingsToggle.addEventListener('click', function (event) {
            event.stopPropagation();
            settingsPanel.classList.toggle('open');
            settingsPanel.setAttribute('aria-hidden', (!settingsPanel.classList.contains('open')).toString());
        });
        document.addEventListener('click', function (event) {
            if (!settingsPanel.contains(event.target) && !settingsToggle.contains(event.target)) {
                settingsPanel.classList.remove('open');
                settingsPanel.setAttribute('aria-hidden', 'true');
            }
        });
    }
});
