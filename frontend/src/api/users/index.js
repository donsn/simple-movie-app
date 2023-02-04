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
                url: "api/user",
                method: "POST",
                body: user,
            }),
        }),
        getUser: builder.query({
            query: () => ({
                url: "api/user",
                method: "GET",
            })
        }),
        loginUser: builder.mutation({
            query: (payload) => ({
                url: "api/user/login",
                method: "POST",
                body: payload,
            }),
        }),
    }),

})

export const {
    useCreateUserMutation,
    useGetUserQuery,
    useLoginUserMutation,
} = usersApi;
