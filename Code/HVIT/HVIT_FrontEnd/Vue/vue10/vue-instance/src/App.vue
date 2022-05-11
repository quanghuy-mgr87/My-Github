<template>
    <div id>
        <h1>{{ msg }}</h1>
        <thong-tin-hoc-sinh></thong-tin-hoc-sinh>
        <!-- <thong-tin-tro-giang></thong-tin-tro-giang> -->
    </div>
    <!-- Chỉ được viết trong 1 thẻ nào đó để vue biết sẽ tương tác với element nào, ko viết nhiều thẻ có cùng cấp
      muốn viết nhiều thẻ phải đóng vào 1 thẻ to -->
    <!-- <div id>
        <h1>{{msg}}</h1>
    </div> -->
</template>
<script>
export default {
    data: function() {
        return {
            msg: "Hello",
        };
    },
};
</script>
