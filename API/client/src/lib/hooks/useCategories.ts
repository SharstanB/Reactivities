import { useQuery } from "@tanstack/react-query";
import agent from "../api/agent";

export const useCategories = () => {
    const {data: categorieslist} =  useQuery({
        queryKey: ['categories'],
          queryFn: async () => {
            const response = await agent.get<BasicListObject[]>('/Categories');
            console.log(response.data);
          return response.data;
        },
        staleTime: 1000 * 60 * 5
      });

  return {
    categorieslist
  };
}
