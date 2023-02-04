import { createApi, fetchBaseQuery } from "@reduxjs/toolkit/dist/query/react";
import { BASE_URL } from "../base";

export const usersApi = createApi({
    reducerPath: "usersApi",
    baseQuery: fetchBaseQuery({
        baseUrl: BASE_URL,
        prepareHeaders: (headers) => {
            headers.set("content-type", "application/json");
            return headers;
        }
    }),
    endpoints: (builder) => ({
        createUser: builder.mutation({
            query: (user) => ({
                url: "api/users",
                method: "POST",
                body: user,
            }),
        }),
        getUser: builder.query({
            query: () => ({
                url: "api/users",
                method: "GET",
            })
        }),
        loginUser: builder.mutation({
            query: (payload) => ({
                url: "api/users/login",
                method: "POST",
                body: payload,
            }),
        }),
    }),

})