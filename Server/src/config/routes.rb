Rails.application.routes.draw do
  root "health_check#index"
  post "/login" => "login#index"
  post "/purchase/add_money" => "purchase#add_money"
end
