import { configureStore } from "@reduxjs/toolkit";
import { moviesApi } from "./movies";
import { usersApi } from "./users";

export const store = configureStore({
    reducer: {
        [moviesApi.reducerPath]: moviesApi.reducer,
        [usersApi.reducerPath]: usersApi.reducer,
    },
    middleware: (getDefaultMiddleware) =>
        getDefaultMiddleware()
        .concat(moviesApi.middleware)
        .concat(usersApi.middleware),
});
