module.exports = {
    extends: [
        "standard",
        "react-app",
        "react-app/jest",
        "plugin:@typescript-eslint/recommended",
        "plugin:@typescript-eslint/recommended-requiring-type-checking",
        "plugin:prettier/recommended",
        "prettier"
    ],
    parser: "@typescript-eslint/parser",
    parserOptions: {
        ecmaFeatures: { jsx: true },
        ecmaVersion: 2019,
        project: "./tsconfig.json"
    },
    plugins: ["standard", "prettier", "@typescript-eslint"],
    settings: { react: { version: "detect" } },
    rules: {
        semi: ["error", "always"],
        "eol-last": ["off"],
        "no-undef": ["error"],
        "no-trailing-spaces": ["off", { skipBlankLines: true }],
        curly: ["error", "all"],
        "no-multiple-empty-lines": ["error"],
        "spaced-comment": ["off"],
        "unicode-bom": ["off"],
        "space-before-function-paren": ["off"],
        "prettier/prettier": ["error"],
        // note you must disable the base rule as it can report incorrect errors
        "no-use-before-define": "off",
        "@typescript-eslint/no-use-before-define": ["error"],
        // note you must disable the base rule as it can report incorrect errors
        "no-unused-vars": "off",
        "@typescript-eslint/no-unused-vars": ["error", { argsIgnorePattern: "^_" }]
    }
};
