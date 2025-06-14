import { useQuery } from "@tanstack/react-query";
import agent from "../api/agent";

export const useCategories = () => {
    const {data: categorieslist} =  useQuery({
        queryKey: ['categories'],
          queryFn: async () => {
            const response = await agent.get<ApiResponse<BasicListObject[]>>('/Categories');
          return response.data.data;
        },
        staleTime: 1000 * 60 * 5
      });

  return {
    categorieslist
  };
}
