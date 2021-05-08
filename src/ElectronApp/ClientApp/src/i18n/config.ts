/* eslint-disable @typescript-eslint/no-unsafe-member-access */
/* eslint-disable @typescript-eslint/no-unsafe-call */
/* eslint-disable @typescript-eslint/no-unsafe-assignment */

import i18n from "i18next";
import { initReactI18next } from "react-i18next";
import translation from "./en/translation.json";

export const resources = {
    en: {
        translation
    }
} as const;

i18n.use(initReactI18next)
    .init({
        lng: "en",
        resources
    })
    .catch((err) => {
        console.error(err);
    });
